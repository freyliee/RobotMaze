namespace RobotMaze;

public class GameView
{
    public void Draw(Graphics g, Robot robot, GameMap map, TextureManager textures)
    {
        float screenWidth = g.VisibleClipBounds.Width;
        float screenHeight = g.VisibleClipBounds.Height;

        float targetWidth = screenWidth * 0.65f;
        float targetHeight = screenHeight * 0.65f;

        float cellSizeX = targetWidth / map.Width;
        float cellSizeY = targetHeight / map.Height;

        float cellSize = Math.Min(cellSizeX, cellSizeY);

        float mapWidthPx = map.Width * cellSize;
        float mapHeightPx = map.Height * cellSize;
        
        float offsetX = (screenWidth - mapWidthPx) / 2;
        float offsetY = (screenHeight - mapHeightPx) / 2;

        for (int x = 0; x < map.Width; x++)
        {
            for (int y = 0; y < map.Height; y++)
            {
                if (map.Tiles[x, y] == TileType.Wall)
                {
                    g.FillRectangle(Brushes.Red, offsetX + x * cellSize, offsetY + y * cellSize, cellSize, cellSize);
                }
                if (map.Tiles[x, y] == TileType.Goal)
                {
                    g.FillRectangle(Brushes.Green, offsetX + x * cellSize, offsetY + y * cellSize, cellSize, cellSize);
                }
            }
        }

        Pen pen = new Pen(Color.LightGray);
        for (int i = 0; i <= map.Width; i++)
        {
            g.DrawLine(pen, offsetX + i * cellSize, offsetY, offsetX + i * cellSize, offsetY + map.Height * cellSize);
        }
        for (int i = 0; i <= map.Height; i++)
        {
            g.DrawLine(pen, offsetX, offsetY + i * cellSize, offsetX + map.Width * cellSize, offsetY + i * cellSize);
        }

        g.FillRectangle(Brushes.Blue, offsetX + robot.X * cellSize + cellSize / 10, offsetY + robot.Y * cellSize + cellSize / 10, cellSize - cellSize / 5, cellSize - cellSize / 5);
        
        int dirX = 0;
        int dirY = 0;
        if (robot.Direction == 0) dirY = -1;
        if (robot.Direction == 1) dirX = 1;
        if (robot.Direction == 2) dirY = 1;
        if (robot.Direction == 3) dirX = -1;
        
        float indicatorSize = cellSize / 5;
        g.FillRectangle(Brushes.White, 
            offsetX + robot.X * cellSize + cellSize / 2 + dirX * (cellSize / 3) - indicatorSize / 2, 
            offsetY + robot.Y * cellSize + cellSize / 2 + dirY * (cellSize / 3) - indicatorSize / 2, 
            indicatorSize, indicatorSize);
    }
}