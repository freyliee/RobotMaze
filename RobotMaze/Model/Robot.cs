using RobotMaze.Model.RobotModules;

namespace RobotMaze.Model;

public class Robot
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public float VisualX { get; set; }
    public float VisualY { get; set; }
    public int Direction { get; private set; }
    public IRobotModule[] Modules { get; }

    public Robot(int x, int y, int moduleSlots)
    {
        X = x;
        Y = y;
        VisualX = x;
        VisualY = y;
        Direction = 0;
        Modules = new IRobotModule[moduleSlots];
    }

    public void MoveForward()
    {
        if (Direction == 0) Y = Y - 1;
        if (Direction == 1) X = X + 1;
        if (Direction == 2) Y = Y + 1;
        if (Direction == 3) X = X - 1;
    }

    public void MoveBackward()
    {
        if (Direction == 0) Y = Y + 1;
        if (Direction == 1) X = X - 1;
        if (Direction == 2) Y = Y - 1;
        if (Direction == 3) X = X + 1;
    }

    public void TurnLeft()
    {
        Direction = Direction - 1;
        if (Direction < 0) Direction = 3;
    }

    public void TurnRight()
    {
        Direction = Direction + 1;
        if (Direction > 3) Direction = 0;
    }
}