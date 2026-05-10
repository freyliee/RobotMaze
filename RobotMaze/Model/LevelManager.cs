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
            "WWWWWWW",
            "WWWWFFW",
            "WFFFFFW",
            "WWWPWWW",
            "WSFFFGW",
            "WFFFFFW",
            "WWWWWWW"
        }, 1, 2, 1, 8));
        levels[0].InitialModules.Add(new ImpulseModule());
        levels[0].InitialModules.Add(new ImpulseModule());
        levels[0].InitialModules.Add(new ImpulseModule());
        levels[0].InitialModules.Add(new Turn180Module());
        levels[0].InitialModules.Add(new TurnLeftModule());
        levels[0].InitialModules.Add(new TurnLeftModule());
        levels[0].InitialModules.Add(new TurnLeftModule());
        levels[0].InitialModules.Add(new BatteringRamModule());
        levels[0].InitialModules.Add(new BatteringRamModule());
        levels[0].InitialModules.Add(new BatteringRamModule());
        levels[0].MapModules.Add(new Point(5, 2), new BridgeModule());

        levels.Add(new LevelData("Уровень 1", new string[]
        {
            "WWWWW",
            "WFSFW",
            "WFPFW",
            "WFFGW",
            "WWWWW"
        }, 1, 1, 1, 7));
        levels[1].InitialModules.Add(new BridgeModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new TurnRightModule());
        levels[1].InitialModules.Add(new TurnRightModule());
        levels[1].InitialModules.Add(new TurnRightModule());
        levels[1].InitialModules.Add(new TurnLeftModule());
        levels[1].InitialModules.Add(new TurnLeftModule());
        levels[1].InitialModules.Add(new TurnLeftModule());
        levels[1].InitialModules.Add(new BatteringRamModule());
        levels[1].InitialModules.Add(new BatteringRamModule());
        levels[1].InitialModules.Add(new BatteringRamModule());
        levels[1].MapModules.Add(new Point(1, 3), new BatteringRamModule());

        levels.Add(new LevelData("Уровень 2", new string[]
        {
            "WWWWW",
            "WFFFW",
            "WFWFW",
            "WFFGW",
            "WWWWW"
        }, 1, 1, 1, 6));
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new TurnRightModule());
        levels[2].InitialModules.Add(new TurnRightModule());
        levels[2].InitialModules.Add(new TurnRightModule());
        levels[2].InitialModules.Add(new TurnLeftModule());
        levels[2].InitialModules.Add(new TurnLeftModule());
        levels[2].InitialModules.Add(new TurnLeftModule());
        levels[2].InitialModules.Add(new BatteringRamModule());
        levels[2].InitialModules.Add(new BatteringRamModule());
        levels[2].InitialModules.Add(new BatteringRamModule());
        levels[2].MapModules.Add(new Point(1, 3), new BatteringRamModule());

        levels.Add(new LevelData("Уровень 3", new string[]
        {
            "WWWWW",
            "WFFFW",
            "WFWFW",
            "WFFGW",
            "WWWWW"
        }, 1, 1, 1));
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new TurnRightModule());
        levels[3].InitialModules.Add(new TurnRightModule());
        levels[3].InitialModules.Add(new TurnRightModule());
        levels[3].InitialModules.Add(new TurnLeftModule());
        levels[3].InitialModules.Add(new TurnLeftModule());
        levels[3].InitialModules.Add(new TurnLeftModule());
        levels[3].InitialModules.Add(new BatteringRamModule());
        levels[3].InitialModules.Add(new BatteringRamModule());
        levels[3].InitialModules.Add(new BatteringRamModule());
        levels[3].MapModules.Add(new Point(1, 3), new BatteringRamModule());

        levels.Add(new LevelData("Уровень 4", new string[]
        {
            "WWWWW",
            "WFFFW",
            "WFWFW",
            "WFFGW",
            "WWWWW"
        }, 1, 1, 1));
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new TurnRightModule());
        levels[4].InitialModules.Add(new TurnRightModule());
        levels[4].InitialModules.Add(new TurnRightModule());
        levels[4].InitialModules.Add(new TurnLeftModule());
        levels[4].InitialModules.Add(new TurnLeftModule());
        levels[4].InitialModules.Add(new TurnLeftModule());
        levels[4].InitialModules.Add(new BatteringRamModule());
        levels[4].InitialModules.Add(new BatteringRamModule());
        levels[4].InitialModules.Add(new BatteringRamModule());
        levels[4].MapModules.Add(new Point(1, 3), new BatteringRamModule());

        levels.Add(new LevelData("Уровень 5", new string[]
        {
            "WWWWW",
            "WFFFW",
            "WFWFW",
            "WFFGW",
            "WWWWW"
        }, 1, 1, 1));
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new TurnRightModule());
        levels[5].InitialModules.Add(new TurnRightModule());
        levels[5].InitialModules.Add(new TurnRightModule());
        levels[5].InitialModules.Add(new TurnLeftModule());
        levels[5].InitialModules.Add(new TurnLeftModule());
        levels[5].InitialModules.Add(new TurnLeftModule());
        levels[5].InitialModules.Add(new BatteringRamModule());
        levels[5].InitialModules.Add(new BatteringRamModule());
        levels[5].InitialModules.Add(new BatteringRamModule());
        levels[5].MapModules.Add(new Point(1, 3), new BatteringRamModule());

        return levels;
    }
}
