using RobotMaze.Model.RobotModules;

namespace RobotMaze.Model;

public class Game
{
    public TextureManager Textures { get; }
    public Robot Robot { get; }
    public GameMap Map { get; }
    public List<IRobotModule> AvailableModules { get; }
    public Dictionary<Point, IRobotModule> MapModules { get; }
    
    public bool IsExecuting { get; private set; }
    public int CurrentModuleIndex { get; private set; } = -1;
    private int executionTimer = 0;
    private const int DelayFrames = 15; 

    public Action OnGoalReached;
    public Action OnGameOver;
    
    public Game(LevelData level)
    {
        Textures = new TextureManager();
        Robot = new Robot(level.StartX, level.StartY, level.ModuleSlots);
        
        Map = new GameMap(level.Map);
        AvailableModules = new List<IRobotModule>(level.InitialModules);
        MapModules = new Dictionary<Point, IRobotModule>(level.MapModules);
    }

    public void StartExecution()
    {
        if (IsExecuting) return;
        
        bool hasModules = false;
        foreach (var m in Robot.Modules) if (m != null) hasModules = true;
        if (!hasModules) return;

        IsExecuting = true;
        CurrentModuleIndex = 0;
        executionTimer = 0;
    }

    public void Update()
    {
        if (IsExecuting)
        {
            UpdateExecution();
        }

        if (Map.Tiles[Robot.X, Robot.Y] == TileType.Goal)
        {
            if (OnGoalReached != null)
            {
                OnGoalReached();
            }
        }

        if (Map.Tiles[Robot.X, Robot.Y] == TileType.Spikes)
        {
            if (OnGameOver != null)
            {
                OnGameOver();
            }
        }

        Point robotPos = new Point(Robot.X, Robot.Y);
        if (MapModules.ContainsKey(robotPos))
        {
            AvailableModules.Add(MapModules[robotPos]);
            MapModules.Remove(robotPos);
        }

        CheckLossConditions();
    }

    private void CheckLossConditions()
    {
        if (IsExecuting) return;

        bool hasModulesInSlots = false;
        for (int i = 0; i < Robot.Modules.Length; i++)
        {
            if (Robot.Modules[i] != null)
            {
                hasModulesInSlots = true;
                break;
            }
        }

        bool robotOnTarget = Map.Tiles[Robot.X, Robot.Y] == TileType.Goal || Map.Tiles[Robot.X, Robot.Y] == TileType.Spikes;

        if (AvailableModules.Count == 0 && !hasModulesInSlots && !robotOnTarget)
        {
            if (OnGameOver != null)
            {
                OnGameOver();
            }
        }
    }

    private void UpdateExecution()
    {
        if (CurrentModuleIndex >= Robot.Modules.Length || Robot.Modules[CurrentModuleIndex] == null)
        {
            FinishExecution();
            return;
        }

        executionTimer++;
        if (executionTimer >= DelayFrames)
        {
            executionTimer = 0;
            IRobotModule module = Robot.Modules[CurrentModuleIndex];
            
            if (module.Execute(Robot, Map))
            {
                Robot.Modules[CurrentModuleIndex] = null;
                CurrentModuleIndex++;
            }
        }
    }

    private void FinishExecution()
    {
        IsExecuting = false;
        CurrentModuleIndex = -1;
        
        for (int i = 0; i < Robot.Modules.Length; i++)
        {
            Robot.Modules[i] = null;
        }
    }

    // public void HandleKey(Keys key)
    // {
    // }
}