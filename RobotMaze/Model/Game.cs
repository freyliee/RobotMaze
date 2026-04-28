namespace RobotMaze;

public class Game
{
    private readonly GameView view;
    public Robot Robot { get; }
    public GameMap Map { get; }
    private Keys? pendingKey;
    
    public Game()
    {
        view = new GameView();
        Robot = new Robot(1, 1);
        
        Map = new GameMap(new TileType[,]
        {
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Floor, TileType.Floor },
            { TileType.Floor, TileType.Floor, TileType.Floor, TileType.Floor, TileType.Floor },
            { TileType.Wall, TileType.Wall, TileType.Floor, TileType.Wall, TileType.Wall },
            { TileType.Floor, TileType.Floor, TileType.Floor, TileType.Floor, TileType.Goal },
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall }
        });
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
            Console.WriteLine("Цель достигнута!");
            Application.Exit();
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
        view.Draw(g, Robot, Map);
    }

    public void HandleKey(Keys key)
    {
        pendingKey = key;
    }
}