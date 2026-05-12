namespace RobotMaze.Model.RobotModules;

public class BatteringRamModule : IRobotModule
{
    public string Name => "Таран";
    public string Description => "Движение до врезания в стену";
    public string TextureName => "module_taran.png";
    public string TooltipTextureName => "tooltip_bg.png";
    
    public bool Execute(Robot robot, GameMap map)
    {
        int nextX = robot.X;
        int nextY = robot.Y;

        if (robot.Direction == 0) nextY--;
        if (robot.Direction == 1) nextX++;
        if (robot.Direction == 2) nextY++;
        if (robot.Direction == 3) nextX--;

        if (map.IsWalkable(nextX, nextY))
        {
            robot.MoveForward();
            
            int afterNextX = robot.X;
            int afterNextY = robot.Y;
            if (robot.Direction == 0) afterNextY--;
            if (robot.Direction == 1) afterNextX++;
            if (robot.Direction == 2) afterNextY++;
            if (robot.Direction == 3) afterNextX--;

            if (!map.IsWalkable(afterNextX, afterNextY))
                return true;
            
            return false;
        }
        return true;
    }
}
