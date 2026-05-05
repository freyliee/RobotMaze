namespace RobotMaze.Model.RobotModules;

public class TurnRightModule : IRobotModule
{
    public string Name => "90 Вправо";
    public string Description => "Поворот робота направо на 90 градусов";
    public string TextureName => "turn_right_module.png";
    public string TooltipTextureName => "tooltip_bg.png";
    
    public bool Execute(Robot robot, GameMap map)
    {
        robot.TurnRight();
        return true;
    }
}
