namespace RobotMaze;

public class Game
{
    private readonly GameView view;
    public TextureManager Textures { get; }
    public Robot Robot { get; }
    public GameMap Map { get; }
    private Keys? pendingKey;
    
    public Action OnGoalReached;
    
    public Game(LevelData level)
    {
        view = new GameView();
        Textures = new TextureManager();
        Robot = new Robot(level.StartX, level.StartY);
        
        Map = new GameMap(level.Map);
    }

    public void Update()
    {
        if (pendingKey != null)
        {
            HandleMovement(pendingKey.Value);
            pendingKey = null;
        }
        
        if (Map.Tiles[Robot.X, Robot.Y] == TileType.Goal)
        {
            if (OnGoalReached != null)
            {
                OnGoalReached();
            }
        }
    }

    private void HandleMovement(Keys key)
    {
        int nextX = Robot.X;
        int nextY = Robot.Y;

        if (key == Keys.W)
        {
            if (Robot.Direction == 0) nextY--;
            if (Robot.Direction == 1) nextX++;
            if (Robot.Direction == 2) nextY++;
            if (Robot.Direction == 3) nextX--;

            if (Map.IsWalkable(nextX, nextY))
            {
                Robot.MoveForward();
            }
        }
        
        if (key == Keys.S)
        {
            if (Robot.Direction == 0) nextY++;
            if (Robot.Direction == 1) nextX--;
            if (Robot.Direction == 2) nextY--;
            if (Robot.Direction == 3) nextX++;

            if (Map.IsWalkable(nextX, nextY))
            {
                Robot.MoveBackward();
            }
        }
        
        if (key == Keys.A) Robot.TurnLeft();
        if (key == Keys.D) Robot.TurnRight();
    }

    public void Draw(Graphics g)
    {
        view.Draw(g, Robot, Map, Textures);
    }

    public void HandleKey(Keys key)
    {
        pendingKey = key;
    }
}