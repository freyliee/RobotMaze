namespace RobotMaze.Model.RobotModules;

public interface IRobotModule
{
    string Name { get; }
    string Description { get; }
    string TextureName { get; }
    string TooltipTextureName { get; }
    bool Execute(Robot robot, GameMap map);
}