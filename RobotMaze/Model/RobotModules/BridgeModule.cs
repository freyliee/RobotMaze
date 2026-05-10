namespace RobotMaze.Model.RobotModules;

public class BridgeModule : IRobotModule
{
    public string Name => "Строительство";
    public string Description => "Строит мост в клетке перед собой";
    public string TextureName => "module_build.png";
    public string TooltipTextureName => "tooltip_bg.png";
    
    public bool Execute(Robot robot, GameMap map)
    {
        int targetX = robot.X;
        int targetY = robot.Y;

        if (robot.Direction == 0) targetY--;
        if (robot.Direction == 1) targetX++;
        if (robot.Direction == 2) targetY++;
        if (robot.Direction == 3) targetX--;

        if (targetX >= 0 && targetX < map.Width && targetY >= 0 && targetY < map.Height)
        {
            map.BuildBridge(targetX, targetY, robot.Direction);
        }
        return true;
    }
}