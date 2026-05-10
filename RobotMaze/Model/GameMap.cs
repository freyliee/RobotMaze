namespace RobotMaze.Model;

public class GameMap
{
    public TileType[,] Tiles { get; private set; }
    public int?[,] Bridges { get; private set; }
    public int Width { get; }
    public int Height { get; }

    public GameMap(TileType[,] tiles)
    {
        Tiles = tiles;
        Width = tiles.GetLength(0);
        Height = tiles.GetLength(1);
        Bridges = new int?[Width, Height];
    }

    public GameMap(int width, int height)
    {
        Width = width;
        Height = height;
        Tiles = new TileType[width, height];
        Bridges = new int?[width, height];
    }

    public void BuildBridge(int x, int y, int direction)
    {
        if (x >= 0 && x < Width && y >= 0 && y < Height)
        {
            Bridges[x, y] = direction;
        }
    }

    public bool IsWalkable(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return false;
        
        return Tiles[x, y] != TileType.Wall;
    }
}