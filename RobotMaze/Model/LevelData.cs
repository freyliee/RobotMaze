using RobotMaze.Model.RobotModules;

namespace RobotMaze.Model;

public class LevelData
{
    public string Name { get; set; }
    public TileType[,] Map { get; set; }
    public int StartX { get; set; }
    public int StartY { get; set; }
    public List<IRobotModule> InitialModules { get; set; }
    public Dictionary<Point, IRobotModule> MapModules { get; set; }
    public int ModuleSlots { get; set; }

    public LevelData(string name, TileType[,] map, int startX, int startY, int slots = 5)
    {
        Name = name;
        Map = map;
        StartX = startX;
        StartY = startY;
        InitialModules = new List<IRobotModule>();
        MapModules = new Dictionary<Point, IRobotModule>();
        ModuleSlots = slots;
    }

    public LevelData(string name, string[] mapData, int startX, int startY, int slots = 5)
    {
        Name = name;
        StartX = startX;
        StartY = startY;
        InitialModules = new List<IRobotModule>();
        MapModules = new Dictionary<Point, IRobotModule>();
        ModuleSlots = slots;

        int height = mapData.Length;
        int width = mapData[0].Length;
        Map = new TileType[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                char c = mapData[y][x];
                if (c == 'W') Map[x, y] = TileType.Wall;
                else if (c == 'F') Map[x, y] = TileType.Floor;
                else if (c == 'G') Map[x, y] = TileType.Goal;
                else if (c == 'S') Map[x, y] = TileType.Spikes;
            }
        }
    }
}
