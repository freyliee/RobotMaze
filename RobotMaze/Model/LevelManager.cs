using RobotMaze.Model.RobotModules;

namespace RobotMaze.Model;

public class LevelManager
{
    public static int UnlockedLevelIndex = 5;
    public static int CompletedLevelIndex = -1;

    public static List<LevelData> GetLevels()
    {
        List<LevelData> levels = new List<LevelData>();

        levels.Add(new LevelData("Обучение", new string[]
        {
            "WWWWWWW",
            "WFFFFFW",
            "WWWWFWW",
            "WFPFFFW",
            "WFWWWWW",
            "WFFFPGW",
            "WWWWWWW"
        }, 1, 1, 1, 3));
        levels[0].InitialModules.Add(new ImpulseModule());
        levels[0].InitialModules.Add(new ImpulseModule());
        levels[0].InitialModules.Add(new ImpulseModule());
        levels[0].InitialModules.Add(new ImpulseModule());
        levels[0].InitialModules.Add(new ImpulseModule());
        levels[0].InitialModules.Add(new Turn180Module());
        levels[0].InitialModules.Add(new TurnLeftModule());
        levels[0].InitialModules.Add(new TurnLeftModule());
        levels[0].InitialModules.Add(new TurnLeftModule());
        levels[0].InitialModules.Add(new TurnRightModule());
        levels[0].InitialModules.Add(new BatteringRamModule());
        levels[0].InitialModules.Add(new BatteringRamModule());
        levels[0].InitialModules.Add(new BatteringRamModule());
        levels[0].InitialModules.Add(new BatteringRamModule());
        levels[0].InitialModules.Add(new BridgeModule());
        levels[0].MapModules.Add(new Point(5, 1), new BridgeModule());

        levels.Add(new LevelData("Уровень 1", new string[]
        {
            "WWWWWWWWW",
            "WSFFFFFFW",
            "WWWPWWWFW",
            "WFFFFFWWW",
            "WFWWWWWFW",
            "WFFPFFFFW",
            "WFWWWPWWW",
            "WFFFWFFGW",
            "WWWWWWWWW"
        }, 7, 2, 0, 4));
        
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        levels[1].InitialModules.Add(new ImpulseModule());
        
        levels[1].InitialModules.Add(new Turn180Module());
        levels[1].InitialModules.Add(new Turn180Module());
        
        levels[1].InitialModules.Add(new TurnLeftModule());
        levels[1].InitialModules.Add(new TurnLeftModule());
        levels[1].InitialModules.Add(new TurnLeftModule());
        levels[1].InitialModules.Add(new TurnLeftModule());
        levels[1].InitialModules.Add(new TurnLeftModule());
        levels[1].InitialModules.Add(new TurnLeftModule());
        levels[1].InitialModules.Add(new TurnLeftModule());
        levels[1].InitialModules.Add(new TurnLeftModule());
        
        levels[1].InitialModules.Add(new TurnRightModule());
        
        levels[1].InitialModules.Add(new BatteringRamModule());
        levels[1].InitialModules.Add(new BatteringRamModule());
        levels[1].InitialModules.Add(new BatteringRamModule());
        levels[1].InitialModules.Add(new BatteringRamModule());
        levels[1].InitialModules.Add(new BatteringRamModule());
        levels[1].InitialModules.Add(new BatteringRamModule());
        
        levels[1].InitialModules.Add(new BridgeModule());
        
        levels[1].MapModules.Add(new Point(5, 3), new BridgeModule());
        levels[1].MapModules.Add(new Point(7, 4), new BridgeModule());

        levels.Add(new LevelData("Уровень 2", new string[]
        {
            "WWWWWWWWW",
            "WFFPFFFFW",
            "WFWWWFWFW",
            "WFWFWFWSW",
            "WFFFWWWFW",
            "WWWFFPFFW",
            "WFWFWWWWW",
            "WFPFFFFGW",
            "WWWWWWWWW"
        }, 5, 3, 0, 4));
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        levels[2].InitialModules.Add(new ImpulseModule());
        
        levels[2].InitialModules.Add(new BridgeModule());
        levels[2].InitialModules.Add(new BridgeModule());
        levels[2].InitialModules.Add(new BridgeModule());
        
        levels[2].InitialModules.Add(new BatteringRamModule());
        
        levels[2].InitialModules.Add(new TurnRightModule());
        levels[2].InitialModules.Add(new TurnRightModule());
        
        levels[2].InitialModules.Add(new TurnLeftModule());
        levels[2].InitialModules.Add(new TurnLeftModule());
        levels[2].InitialModules.Add(new TurnLeftModule());
        
        levels[2].InitialModules.Add(new Turn180Module());
        levels[2].InitialModules.Add(new Turn180Module());
        levels[2].InitialModules.Add(new Turn180Module());
        
        levels[2].MapModules.Add(new Point(7, 1), new BatteringRamModule());
        levels[2].MapModules.Add(new Point(7, 5), new BatteringRamModule());
        levels[2].MapModules.Add(new Point(1, 7), new BatteringRamModule());

        levels.Add(new LevelData("Уровень 3", new string[]
        {
            "WWWWWWWWWWW",
            "WFWWFWWFFFW",
            "WFFFFFFFFFW",
            "WWFWWSWWWFW",
            "WFFWFFWFWFW",
            "WFWWFPFFWFW",
            "WWWFFWWPWFW",
            "WFFFFFSFFFW",
            "WWWFWWWWWFW",
            "WFFFPFFGWFW",
            "WWWWWWWWWWW"
        }, 1, 5, 0, 5));
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());
        levels[3].InitialModules.Add(new ImpulseModule());

        levels[3].InitialModules.Add(new TurnRightModule());
        levels[3].InitialModules.Add(new TurnRightModule());
        levels[3].InitialModules.Add(new TurnRightModule());
        levels[3].InitialModules.Add(new TurnRightModule());
        levels[3].InitialModules.Add(new TurnRightModule());
        levels[3].InitialModules.Add(new TurnLeftModule());
        levels[3].InitialModules.Add(new TurnLeftModule());
        levels[3].InitialModules.Add(new TurnLeftModule());
        levels[3].InitialModules.Add(new TurnLeftModule());
        levels[3].InitialModules.Add(new TurnLeftModule());
        levels[3].InitialModules.Add(new Turn180Module());
        levels[3].InitialModules.Add(new Turn180Module());
        levels[3].InitialModules.Add(new Turn180Module());
        levels[3].InitialModules.Add(new Turn180Module());
        
        levels[3].InitialModules.Add(new BatteringRamModule());
        levels[3].InitialModules.Add(new BatteringRamModule());
        levels[3].InitialModules.Add(new BatteringRamModule());
        levels[3].InitialModules.Add(new BatteringRamModule());
        levels[3].InitialModules.Add(new BatteringRamModule());
        levels[3].InitialModules.Add(new BatteringRamModule());
        levels[3].InitialModules.Add(new BatteringRamModule());
        levels[3].InitialModules.Add(new BatteringRamModule());

        levels[3].InitialModules.Add(new BridgeModule());

        levels[3].MapModules.Add(new Point(1, 2), new BatteringRamModule());
        levels[3].MapModules.Add(new Point(7, 4), new BridgeModule());
        levels[3].MapModules.Add(new Point(1, 7), new BridgeModule());

        levels.Add(new LevelData("Уровень 4", new string[]
        {
            "WWWWWWWWWWW",
            "WFFFFPFFFFW",
            "WWWFWWWFWWW",
            "WSWPWWWFWFW",
            "WFWFFFWFFFW",
            "WFFFWFWWWWW",
            "WWWWWPWFFFW",
            "WSFFFFFFWFW",
            "WWWFWWWPWWW",
            "WSFFFWFFFGW",
            "WWWWWWWWWWW"
        }, 1, 1, 1, 5));
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        levels[4].InitialModules.Add(new ImpulseModule());
        
        levels[4].InitialModules.Add(new TurnRightModule());
        levels[4].InitialModules.Add(new TurnRightModule());
        levels[4].InitialModules.Add(new TurnRightModule());
        levels[4].InitialModules.Add(new TurnRightModule());
        levels[4].InitialModules.Add(new TurnRightModule());
        levels[4].InitialModules.Add(new TurnRightModule());
        levels[4].InitialModules.Add(new TurnRightModule());
        levels[4].InitialModules.Add(new TurnRightModule());
        
        levels[4].InitialModules.Add(new TurnLeftModule());
        levels[4].InitialModules.Add(new TurnLeftModule());
        levels[4].InitialModules.Add(new TurnLeftModule());
        levels[4].InitialModules.Add(new TurnLeftModule());
        levels[4].InitialModules.Add(new TurnLeftModule());
        levels[4].InitialModules.Add(new TurnLeftModule());
        
        levels[4].InitialModules.Add(new BatteringRamModule());
        levels[4].InitialModules.Add(new BatteringRamModule());
        levels[4].InitialModules.Add(new BatteringRamModule());
        levels[4].InitialModules.Add(new BatteringRamModule());
        levels[4].InitialModules.Add(new BatteringRamModule());
        levels[4].InitialModules.Add(new BatteringRamModule());
        levels[4].InitialModules.Add(new BatteringRamModule());
        levels[4].InitialModules.Add(new BatteringRamModule());
        levels[4].InitialModules.Add(new BatteringRamModule());
        
        levels[4].InitialModules.Add(new Turn180Module());
        levels[4].InitialModules.Add(new Turn180Module());
        levels[4].InitialModules.Add(new Turn180Module());
        
        levels[4].MapModules.Add(new Point(4, 1), new BridgeModule());
        levels[4].MapModules.Add(new Point(1, 4), new BridgeModule());
        levels[4].MapModules.Add(new Point(2, 9), new BridgeModule());

        levels.Add(new LevelData("Уровень 5", new string[]
        {
            "WWWWWWWWWWWWW",
            "WFFFFFWFFFFFW",
            "WFWWWFFFSWWFW",
            "WFWFWWWWWFWFW",
            "WFWFFFFFFFWFW",
            "SFPFWWPWWFWFW",
            "WWWWWFFFWFWFW",
            "WGWFWPWWWWWFW",
            "WFWFFFWFWFWFW",
            "WFWSWFWFFFPFW",
            "SFFFWWWFWWWFW",
            "WFWFFFPFFSFFW",
            "WWWWWWWSWWWWW"
        }, 3, 3, 2, 6));
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        levels[5].InitialModules.Add(new ImpulseModule());
        
        levels[5].InitialModules.Add(new TurnRightModule());
        levels[5].InitialModules.Add(new TurnRightModule());
        levels[5].InitialModules.Add(new TurnRightModule());
        levels[5].InitialModules.Add(new TurnRightModule());
        levels[5].InitialModules.Add(new TurnRightModule());
        levels[5].InitialModules.Add(new TurnRightModule());
        levels[5].InitialModules.Add(new TurnRightModule());
        levels[5].InitialModules.Add(new TurnRightModule());
        levels[5].InitialModules.Add(new TurnRightModule());
        
        levels[5].InitialModules.Add(new TurnLeftModule());
        levels[5].InitialModules.Add(new TurnLeftModule());
        levels[5].InitialModules.Add(new TurnLeftModule());
        levels[5].InitialModules.Add(new TurnLeftModule());
        levels[5].InitialModules.Add(new TurnLeftModule());
        levels[5].InitialModules.Add(new TurnLeftModule());
        levels[5].InitialModules.Add(new TurnLeftModule());
        levels[5].InitialModules.Add(new TurnLeftModule());
        levels[5].InitialModules.Add(new TurnLeftModule());
        
        levels[5].InitialModules.Add(new BatteringRamModule());
        levels[5].InitialModules.Add(new BatteringRamModule());
        levels[5].InitialModules.Add(new BatteringRamModule());
        levels[5].InitialModules.Add(new BatteringRamModule());
        levels[5].InitialModules.Add(new BatteringRamModule());
        levels[5].InitialModules.Add(new BatteringRamModule());
        levels[5].InitialModules.Add(new BatteringRamModule());
        levels[5].InitialModules.Add(new BatteringRamModule());
        levels[5].InitialModules.Add(new BatteringRamModule());
        
        levels[5].InitialModules.Add(new Turn180Module());
        levels[5].InitialModules.Add(new Turn180Module());
        levels[5].InitialModules.Add(new Turn180Module());
        
        levels[5].MapModules.Add(new Point(9, 4), new BridgeModule());
        levels[5].MapModules.Add(new Point(10, 11), new BridgeModule());
        levels[5].MapModules.Add(new Point(8, 11), new BridgeModule());

        return levels;
    }
}
