namespace RobotMaze;

public class GameView
{
    public void Draw(Graphics g, Robot robot, GameMap map)
    {
        int cellSize = 50;

        for (int x = 0; x < map.Width; x++)
        {
            for (int y = 0; y < map.Height; y++)
            {
                if (map.Tiles[x, y] == TileType.Wall)
                {
                    g.FillRectangle(Brushes.Red, x * cellSize, y * cellSize, cellSize, cellSize);
                }
                if (map.Tiles[x, y] == TileType.Goal)
                {
                    g.FillRectangle(Brushes.Green, x * cellSize, y * cellSize, cellSize, cellSize);
                }
            }
        }

        Pen pen = new Pen(Color.LightGray);
        for (int i = 0; i <= map.Width; i++)
        {
            g.DrawLine(pen, i * cellSize, 0, i * cellSize, map.Height * cellSize);
        }
        for (int i = 0; i <= map.Height; i++)
        {
            g.DrawLine(pen, 0, i * cellSize, map.Width * cellSize, i * cellSize);
        }

        g.FillRectangle(Brushes.Blue, robot.X * cellSize + 5, robot.Y * cellSize + 5, cellSize - 10, cellSize - 10);
        
        int dirX = 0;
        int dirY = 0;
        if (robot.Direction == 0) dirY = -1;
        if (robot.Direction == 1) dirX = 1;
        if (robot.Direction == 2) dirY = 1;
        if (robot.Direction == 3) dirX = -1;
        
        g.FillRectangle(Brushes.White, 
            robot.X * cellSize + cellSize / 2 + dirX * 15 - 5, 
            robot.Y * cellSize + cellSize / 2 + dirY * 15 - 5, 
            10, 10);
    }
}