namespace RobotMaze;

public interface IRobotModule
{
    string Name { get; }
    void Execute(Robot robot);
}