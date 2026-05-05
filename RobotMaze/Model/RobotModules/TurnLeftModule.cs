namespace RobotMaze.Model.RobotModules;

public class TurnLeftModule : IRobotModule
{
    public string Name => "90 Влево";
    public string Description => "Поворот робота налево на 90 градусов";
    public string TextureName => "turn_left_module.png";
    public string TooltipTextureName => "tooltip_bg.png";
    
    public bool Execute(Robot robot, GameMap map)
    {
        robot.TurnLeft();
        return true;
    }
}
