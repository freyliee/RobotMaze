namespace RobotMaze;

public class LevelManager
{
    public static int UnlockedLevelIndex = 0;

    public static List<LevelData> GetLevels()
    {
        List<LevelData> levels = new List<LevelData>();

        levels.Add(new LevelData("Обучение", new TileType[,]
        {
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Floor, TileType.Floor },
            { TileType.Floor, TileType.Floor, TileType.Floor, TileType.Floor, TileType.Floor },
            { TileType.Wall, TileType.Wall, TileType.Floor, TileType.Wall, TileType.Wall },
            { TileType.Floor, TileType.Floor, TileType.Floor, TileType.Floor, TileType.Goal },
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall }
        }, 1, 1));

        levels.Add(new LevelData("Уровень 1", new TileType[,]
        {
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Floor, TileType.Floor, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Wall, TileType.Floor, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Floor, TileType.Goal, TileType.Wall },
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall }
        }, 1, 1));

        levels.Add(new LevelData("Уровень 2", new TileType[,]
        {
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Floor, TileType.Floor, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Wall, TileType.Floor, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Floor, TileType.Goal, TileType.Wall },
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall }
        }, 1, 1));

        levels.Add(new LevelData("Уровень 3", new TileType[,]
        {
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Floor, TileType.Floor, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Wall, TileType.Floor, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Floor, TileType.Goal, TileType.Wall },
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall }
        }, 1, 1));

        levels.Add(new LevelData("Уровень 4", new TileType[,]
        {
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Floor, TileType.Floor, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Wall, TileType.Floor, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Floor, TileType.Goal, TileType.Wall },
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall }
        }, 1, 1));

        levels.Add(new LevelData("Уровень 5", new TileType[,]
        {
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Floor, TileType.Floor, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Wall, TileType.Floor, TileType.Wall },
            { TileType.Wall, TileType.Floor, TileType.Floor, TileType.Goal, TileType.Wall },
            { TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall, TileType.Wall }
        }, 1, 1));

        return levels;
    }
}
