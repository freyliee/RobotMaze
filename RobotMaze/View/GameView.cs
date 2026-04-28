namespace RobotMaze;

public class GameView
{
    public void Draw(Graphics g, Robot robot)
    {
        int cellSize = 50;
        
        Pen pen = new Pen(Color.LightGray);
        for (int i = 0; i < 20; i++)
        {
            g.DrawLine(pen, i * cellSize, 0, i * cellSize, 1000);
            g.DrawLine(pen, 0, i * cellSize, 1000, i * cellSize);
        }
        
        g.FillRectangle(Brushes.Blue, robot.X * cellSize + 5, robot.Y * cellSize + 5, cellSize - 10, cellSize - 10);
        
        int dirX = 0;
        int dirY = 0;
        if (robot.Direction == 0) dirY = -1;
        if (robot.Direction == 1) dirX = 1;
        if (robot.Direction == 2) dirY = 1;
        if (robot.Direction == 3) dirX = -1;
        
        g.FillRectangle(Brushes.Red, 
            robot.X * cellSize + cellSize / 2 + dirX * 15 - 5, 
            robot.Y * cellSize + cellSize / 2 + dirY * 15 - 5, 
            10, 10);
    }
}