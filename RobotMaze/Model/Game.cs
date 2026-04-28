namespace RobotMaze;

public class Game
{
    private readonly GameView view;
    public Robot Robot { get; }
    
    public Game()
    {
        view = new GameView();
        Robot = new Robot(1, 1);
    }

    public void Update()
    {
        
    }

    public void Draw(Graphics g)
    {
        view.Draw(g, Robot);
    }

    public void HandleKey(Keys key)
    {
        if (key == Keys.W) Robot.MoveForward();
        if (key == Keys.S) Robot.MoveBackward();
        if (key == Keys.A) Robot.TurnLeft();
        if (key == Keys.D) Robot.TurnRight();
    }
}