namespace RobotMaze.Model.RobotModules;

public class Turn180Module : IRobotModule
{
    public string Name => "180 Градусов";
    public string Description => "Разворачивает робота на 180 градусов";
    public string TextureName => "module_rotate_180.png";
    public string TooltipTextureName => "tooltip_bg.png";
    
    public bool Execute(Robot robot, GameMap map)
    {
        robot.TurnRight();
        robot.TurnRight();
        return true;
    }
}