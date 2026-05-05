using RobotMaze.Model;
using RobotMaze.Model.RobotModules;

namespace RobotMaze.Controller;

public class GameController
{
    private readonly Game game;

    public GameController(Game game)
    {
        this.game = game;
    }

    public void Update()
    {
        game.Update();
    }

    public void StartExecution()
    {
        game.StartExecution();
    }

    public void HandleDragAndDrop(IRobotModule draggingModule, int sourceIdx, bool isFromAvailable, Point dropPoint, Size containerSize)
    {
        float screenWidth = containerSize.Width;
        float screenHeight = containerSize.Height;
        float bottomPanelHeight = screenHeight * 0.15f;
        float slotSize = bottomPanelHeight * 0.8f;
        float slotsTotalWidth = game.Robot.Modules.Length * slotSize + (game.Robot.Modules.Length - 1) * 10;
        float slotsStartX = (screenWidth - slotsTotalWidth) / 2;
        float slotsStartY = screenHeight - bottomPanelHeight + (bottomPanelHeight - slotSize) / 2;

        bool droppedOnSlot = false;
        for (int i = 0; i < game.Robot.Modules.Length; i++)
        {
            float x = slotsStartX + i * (slotSize + 10);
            if (dropPoint.X >= x && dropPoint.X <= x + slotSize && dropPoint.Y >= slotsStartY && dropPoint.Y <= slotsStartY + slotSize)
            {
                if (isFromAvailable)
                {
                    game.AvailableModules.RemoveAt(sourceIdx);
                    if (game.Robot.Modules[i] != null)
                    {
                        game.AvailableModules.Add(game.Robot.Modules[i]);
                    }
                    game.Robot.Modules[i] = draggingModule;
                }
                else
                {
                    IRobotModule targetModule = game.Robot.Modules[i];
                    game.Robot.Modules[sourceIdx] = targetModule;
                    game.Robot.Modules[i] = draggingModule;
                }
                droppedOnSlot = true;
                break;
            }
        }

        if (!droppedOnSlot && !isFromAvailable)
        {
            game.AvailableModules.Add(draggingModule);
            game.Robot.Modules[sourceIdx] = null;
        }

        ShiftModulesLeft();
    }

    private void ShiftModulesLeft()
    {
        int nextSlot = 0;
        for (int i = 0; i < game.Robot.Modules.Length; i++)
        {
            if (game.Robot.Modules[i] != null)
            {
                IRobotModule m = game.Robot.Modules[i];
                game.Robot.Modules[i] = null;
                game.Robot.Modules[nextSlot] = m;
                nextSlot++;
            }
        }
    }
}
