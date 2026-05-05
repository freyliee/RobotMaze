using RobotMaze.Model.RobotModules;

namespace RobotMaze.Model;

public class LevelManager
{
    public static int UnlockedLevelIndex = 0;
    public static int CompletedLevelIndex = -1;

    public static List<LevelData> GetLevels()
    {
        List<LevelData> levels = new List<LevelData>();

        levels.Add(new LevelData("Обучение", new string[]
        {
            "WWWFF",
            "FFFFF",
            "WWFWW",
            "SFFFG",
            "WWWWW"
        }, 1, 1));
        levels[0].InitialModules.Add(new ImpulseModule());
        levels[0].InitialModules.Add(new ImpulseModule());
        levels[0].InitialModules.Add(new ImpulseModule());
        levels[0].InitialModules.Add(new TurnRightModule());
        levels[0].InitialModules.Add(new TurnRightModule());
        levels[0].InitialModules.Add(new TurnRightModule());
        levels[0].InitialModules.Add(new TurnLeftModule());
        levels[0].InitialModules.Add(new TurnLeftModule());
        levels[0].InitialModules.Add(new TurnLeftModule());
        levels[0].InitialModules.Add(new BatteringRamModule());
        levels[0].InitialModules.Add(new BatteringRamModule());
        levels[0].InitialModules.Add(new BatteringRamModule());
        levels[0].MapModules.Add(new Point(1, 3), new BatteringRamModule());

        levels.Add(new LevelData("Уровень 1", new string[]
        {
            "WWWWW",
            "WFSFW",
            "WFWFW",
            "WFFGW",
            "WWWWW"
        }, 1, 1));

        levels.Add(new LevelData("Уровень 2", new string[]
        {
            "WWWWW",
            "WFFFW",
            "WFWFW",
            "WFFGW",
            "WWWWW"
        }, 1, 1));

        levels.Add(new LevelData("Уровень 3", new string[]
        {
            "WWWWW",
            "WFFFW",
            "WFWFW",
            "WFFGW",
            "WWWWW"
        }, 1, 1));

        levels.Add(new LevelData("Уровень 4", new string[]
        {
            "WWWWW",
            "WFFFW",
            "WFWFW",
            "WFFGW",
            "WWWWW"
        }, 1, 1));

        levels.Add(new LevelData("Уровень 5", new string[]
        {
            "WWWWW",
            "WFFFW",
            "WFWFW",
            "WFFGW",
            "WWWWW"
        }, 1, 1));

        return levels;
    }
}
