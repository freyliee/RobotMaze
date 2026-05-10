using RobotMaze.Model.RobotModules;

namespace RobotMaze.Model;

public class Game
{
    public string LevelName { get; }
    public TextureManager Textures { get; }
    public Robot Robot { get; }
    public GameMap Map { get; }
    public List<IRobotModule> AvailableModules { get; }
    public Dictionary<Point, IRobotModule> MapModules { get; }
    
    public bool IsExecuting { get; private set; }
    public int CurrentModuleIndex { get; private set; } = -1;
    private int executionTimer = 0;
    private const int DelayFrames = 30; 

    private float prevX;
    private float prevY;
    private bool isMoving = false;

    public Action OnGoalReached;
    public Action OnGameOver;
    
    public Game(LevelData level)
    {
        LevelName = level.Name;
        Textures = new TextureManager();
        Robot = new Robot(level.StartX, level.StartY, level.StartDirection, level.ModuleSlots);
        
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

        if (!isMoving)
        {
            if (Map.Tiles[Robot.X, Robot.Y] == TileType.Goal)
            {
                if (OnGoalReached != null)
                {
                    OnGoalReached();
                }
            }

            if (Map.Tiles[Robot.X, Robot.Y] == TileType.Spikes || (Map.Tiles[Robot.X, Robot.Y] == TileType.Puddle && Map.Bridges[Robot.X, Robot.Y] == null))
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

        bool robotOnTarget = Map.Tiles[Robot.X, Robot.Y] == TileType.Goal || Map.Tiles[Robot.X, Robot.Y] == TileType.Spikes || (Map.Tiles[Robot.X, Robot.Y] == TileType.Puddle && Map.Bridges[Robot.X, Robot.Y] == null);

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
        if (!isMoving)
        {
            if (CurrentModuleIndex >= Robot.Modules.Length || Robot.Modules[CurrentModuleIndex] == null)
            {
                FinishExecution();
                return;
            }

            prevX = Robot.X;
            prevY = Robot.Y;
            isMoving = true;
            executionTimer = 0;
            
            IRobotModule module = Robot.Modules[CurrentModuleIndex];
            if (module.Execute(Robot, Map))
            {
                Robot.Modules[CurrentModuleIndex] = null;
                CurrentModuleIndex++;
            }
        }

        if (isMoving)
        {
            executionTimer++;
            float t = (float)executionTimer / DelayFrames;
            if (t > 1) t = 1;

            float moveStart = 0.3f;
            float moveEnd = 0.7f;
            float moveT = 0;

            if (t > moveEnd) moveT = 1;
            else if (t > moveStart) moveT = (t - moveStart) / (moveEnd - moveStart);

            float easeT = moveT * moveT * (3 - 2 * moveT);

            Robot.VisualX = prevX + (Robot.X - prevX) * easeT;
            Robot.VisualY = prevY + (Robot.Y - prevY) * easeT;

            if (executionTimer >= DelayFrames)
            {
                isMoving = false;
                Robot.VisualX = Robot.X;
                Robot.VisualY = Robot.Y;
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
}