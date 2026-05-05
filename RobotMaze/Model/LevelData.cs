namespace RobotMaze;

public class LevelData
{
    public string Name { get; set; }
    public TileType[,] Map { get; set; }
    public int StartX { get; set; }
    public int StartY { get; set; }

    public LevelData(string name, TileType[,] map, int startX, int startY)
    {
        Name = name;
        Map = map;
        StartX = startX;
        StartY = startY;
    }
}
