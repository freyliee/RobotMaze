namespace RobotMaze.Model.RobotModules;

public class ImpulseModule : IRobotModule
{
    public string Name => "Импульс";
    public string Description => "Движение на 1 клетку вперёд";
    public string TextureName => "module_impulse.png";
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
        }
        return true;
    }
}
