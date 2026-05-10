using System.Drawing.Drawing2D;
using RobotMaze.Model.RobotModules;

namespace RobotMaze.View;

using Model;

public class GameView
{
    public void Draw(Graphics g, Game game, IRobotModule draggingModule = null, IRobotModule hoveredModule = null, Point mousePos = default)
    {
        g.InterpolationMode = InterpolationMode.NearestNeighbor;
        g.PixelOffsetMode = PixelOffsetMode.Half;

        Robot robot = game.Robot;
        GameMap map = game.Map;
        TextureManager textures = game.Textures;

        float screenWidth = g.VisibleClipBounds.Width;
        float screenHeight = g.VisibleClipBounds.Height;

        float leftPanelWidth = screenWidth * 0.15f;
        float bottomPanelHeight = screenHeight * 0.15f;

        float targetWidth = screenWidth * 0.65f;
        float targetHeight = screenHeight * 0.65f;

        float cellSizeX = targetWidth / map.Width;
        float cellSizeY = targetHeight / map.Height;

        float cellSize = Math.Min(cellSizeX, cellSizeY);

        float mapWidthPx = map.Width * cellSize;
        float mapHeightPx = map.Height * cellSize;
        
        float offsetX = (screenWidth - mapWidthPx) / 2;
        float offsetY = (screenHeight - mapHeightPx) / 2;

        Image wallTexture = textures.GetTexture("wall.jpg");
        Image grassTexture = textures.GetTexture("grass.png");
        Image spikesTexture = textures.GetTexture("spikes.jpg");
        Image puddleTexture = textures.GetTexture("water.jpg");
        Image bridgeTexture = textures.GetTexture("bridge.png");
        Image finishTexture = textures.GetTexture("finish.png");

        if (grassTexture != null)
        {
            using (TextureBrush grassBrush = new TextureBrush(grassTexture))
            {
                g.FillRectangle(grassBrush, 0, 0, screenWidth, screenHeight);
            }
        }
        else
        {
            g.Clear(Color.FromArgb(255, 100, 200, 100));
        }

        for (int x = 0; x < map.Width; x++)
        {
            for (int y = 0; y < map.Height; y++)
            {
                if (map.Tiles[x, y] == TileType.Wall)
                {
                    if (wallTexture != null)
                    {
                        g.DrawImage(wallTexture, offsetX + x * cellSize, offsetY + y * cellSize, cellSize, cellSize);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Red, offsetX + x * cellSize, offsetY + y * cellSize, cellSize, cellSize);
                    }
                }
                if (map.Tiles[x, y] == TileType.Goal)
                {
                    if (finishTexture != null)
                    {
                        g.DrawImage(finishTexture, offsetX + x * cellSize, offsetY + y * cellSize, cellSize, cellSize);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Green, offsetX + x * cellSize, offsetY + y * cellSize, cellSize, cellSize);
                    }
                }
                if (map.Tiles[x, y] == TileType.Spikes)
                {
                    if (spikesTexture != null)
                    {
                        g.DrawImage(spikesTexture, offsetX + x * cellSize, offsetY + y * cellSize, cellSize, cellSize);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.DarkGray, offsetX + x * cellSize, offsetY + y * cellSize, cellSize, cellSize);
                    }
                }
                if (map.Tiles[x, y] == TileType.Puddle)
                {
                    if (puddleTexture != null)
                    {
                        g.DrawImage(puddleTexture, offsetX + x * cellSize, offsetY + y * cellSize, cellSize, cellSize);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Blue, offsetX + x * cellSize, offsetY + y * cellSize, cellSize, cellSize);
                    }
                }

                if (map.Bridges[x, y].HasValue)
                {
                    if (bridgeTexture != null)
                    {
                        float centerX = offsetX + x * cellSize + cellSize / 2;
                        float centerY = offsetY + y * cellSize + cellSize / 2;
                        var state = g.Save();
                        g.TranslateTransform(centerX, centerY);
                        g.RotateTransform(map.Bridges[x, y].Value * 90 + 180);
                        g.DrawImage(bridgeTexture, -cellSize / 2, -cellSize / 2, cellSize, cellSize);
                        g.Restore(state);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.SaddleBrown, offsetX + x * cellSize + cellSize / 4, offsetY + y * cellSize + cellSize / 4, cellSize / 2, cellSize / 2);
                    }
                }

                Point p = new Point(x, y);
                if (game.MapModules.ContainsKey(p))
                {
                    IRobotModule mapModule = game.MapModules[p];
                    Image modImg = textures.GetTexture(mapModule.TextureName);
                    if (modImg != null)
                    {
                        g.DrawImage(modImg, offsetX + x * cellSize + cellSize / 4, offsetY + y * cellSize + cellSize / 4, cellSize / 2, cellSize / 2);
                    }
                    else
                    {
                        g.FillEllipse(Brushes.Orange, offsetX + x * cellSize + cellSize / 4, offsetY + y * cellSize + cellSize / 4, cellSize / 2, cellSize / 2);
                    }
                }
            }
        }


        Image robotTexture = textures.GetTexture("robot.png");
        if (robotTexture != null)
        {
            float centerX = offsetX + robot.VisualX * cellSize + cellSize / 2;
            float centerY = offsetY + robot.VisualY * cellSize + cellSize / 2;
            float robotSize = cellSize - cellSize / 5;

            var state = g.Save();
            g.TranslateTransform(centerX, centerY);
            
            g.RotateTransform(robot.Direction * 90 + 180);
            
            g.DrawImage(robotTexture, -robotSize / 2, -robotSize / 2, robotSize, robotSize);
            g.Restore(state);
        }
        else
        {
            g.FillRectangle(Brushes.Blue, offsetX + robot.VisualX * cellSize + cellSize / 10, offsetY + robot.VisualY * cellSize + cellSize / 10, cellSize - cellSize / 5, cellSize - cellSize / 5);
        }
        
        int dirX = 0;
        int dirY = 0;
        if (robot.Direction == 0) dirY = -1;
        if (robot.Direction == 1) dirX = 1;
        if (robot.Direction == 2) dirY = 1;
        if (robot.Direction == 3) dirX = -1;

        float slotSize = bottomPanelHeight * 0.8f;
        float slotsTotalWidth = robot.Modules.Length * slotSize + (robot.Modules.Length - 1) * 10;
        float slotsStartX = (screenWidth - slotsTotalWidth) / 2;
        float slotsStartY = screenHeight - bottomPanelHeight + (bottomPanelHeight - slotSize) / 2;

        for (int i = 0; i < robot.Modules.Length; i++)
        {
            float x = slotsStartX + i * (slotSize + 10);
            
            Image slotImg = textures.GetTexture("slot.png");
            if (slotImg != null)
            {
                g.DrawImage(slotImg, x, slotsStartY, slotSize, slotSize);
            }
            else
            {
                g.DrawRectangle(Pens.White, x, slotsStartY, slotSize, slotSize);
            }

            if (robot.Modules[i] != null && robot.Modules[i] != draggingModule)
            {
                Image modImg = textures.GetTexture(robot.Modules[i].TextureName);
                if (modImg != null)
                {
                    g.DrawImage(modImg, x + 5, slotsStartY + 5, slotSize - 10, slotSize - 10);
                }
                else
                {
                    g.FillRectangle(Brushes.Yellow, x + 5, slotsStartY + 5, slotSize - 10, slotSize - 10);
                    g.DrawString(robot.Modules[i].Name.Substring(0, Math.Min(2, robot.Modules[i].Name.Length)), 
                        new Font("Arial", slotSize / 4), Brushes.Black, x + 10, slotsStartY + 10);
                }
            }

            if (game.IsExecuting && game.CurrentModuleIndex == i)
            {
                using (SolidBrush highlightBrush = new SolidBrush(Color.FromArgb(100, Color.LightGreen)))
                {
                    g.FillRectangle(highlightBrush, x, slotsStartY, slotSize, slotSize);
                }
            }
        }

        float moduleBoxSize = leftPanelWidth * 0.4f;
        for (int i = 0; i < game.AvailableModules.Count; i++)
        {
            int col = i % 2;
            int row = i / 2;
            float moduleBoxX = (leftPanelWidth / 2 - moduleBoxSize) / 2 + col * (leftPanelWidth / 2);
            float y = 50 + row * (moduleBoxSize + 10);
            
            if (game.AvailableModules[i] != draggingModule)
            {
                Image modImg = textures.GetTexture(game.AvailableModules[i].TextureName);
                if (modImg != null)
                {
                    g.DrawImage(modImg, moduleBoxX, y, moduleBoxSize, moduleBoxSize);
                }
                else
                {
                    g.FillRectangle(Brushes.Yellow, moduleBoxX, y, moduleBoxSize, moduleBoxSize);
                    g.DrawRectangle(Pens.Black, moduleBoxX, y, moduleBoxSize, moduleBoxSize);
                    g.DrawString(game.AvailableModules[i].Name.Substring(0, Math.Min(2, game.AvailableModules[i].Name.Length)), 
                        new Font("Arial", moduleBoxSize / 4), Brushes.Black, moduleBoxX + 5, y + 5);
                }
            }
        }

        if (draggingModule != null)
        {
            float dragSize = Math.Max(slotSize, moduleBoxSize);
            Image modImg = textures.GetTexture(draggingModule.TextureName);
            if (modImg != null)
            {
                g.DrawImage(modImg, mousePos.X - dragSize / 2, mousePos.Y - dragSize / 2, dragSize, dragSize);
            }
            else
            {
                g.FillRectangle(Brushes.Yellow, mousePos.X - dragSize / 2, mousePos.Y - dragSize / 2, dragSize, dragSize);
                g.DrawRectangle(Pens.Black, mousePos.X - dragSize / 2, mousePos.Y - dragSize / 2, dragSize, dragSize);
                g.DrawString(draggingModule.Name.Substring(0, Math.Min(2, draggingModule.Name.Length)), 
                    new Font("Arial", dragSize / 4), Brushes.Black, mousePos.X - dragSize / 2 + 5, mousePos.Y - dragSize / 2 + 5);
            }
        }

        float runBtnWidth = 100;
        float runBtnHeight = 50;
        float runBtnX = screenWidth - runBtnWidth - 20;
        float runBtnY = screenHeight - runBtnHeight - 20;
        g.FillRectangle(Brushes.LightGreen, runBtnX, runBtnY, runBtnWidth, runBtnHeight);
        g.DrawRectangle(Pens.Black, runBtnX, runBtnY, runBtnWidth, runBtnHeight);
        g.DrawString("ЗАПУСК", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, runBtnX + 10, runBtnY + 15);

        float restartBtnWidth = 100;
        float restartBtnHeight = 40;
        float restartBtnX = screenWidth - restartBtnWidth - 20;
        float restartBtnY = 20;
        g.FillRectangle(Brushes.LightCoral, restartBtnX, restartBtnY, restartBtnWidth, restartBtnHeight);
        g.DrawRectangle(Pens.Black, restartBtnX, restartBtnY, restartBtnWidth, restartBtnHeight);
        g.DrawString("РЕСТАРТ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, restartBtnX + 10, restartBtnY + 10);

        Font titleFont = new Font("Arial", 20, FontStyle.Bold);
        SizeF titleSize = g.MeasureString(game.LevelName, titleFont);
        g.DrawString(game.LevelName, titleFont, Brushes.White, (screenWidth - titleSize.Width) / 2, 20);

        if (hoveredModule != null && draggingModule == null)
        {
            float tooltipWidth = 200;
            float tooltipHeight = 100;
            float tooltipX = mousePos.X + 10;
            float tooltipY = mousePos.Y + 10;

            if (tooltipX + tooltipWidth > screenWidth) tooltipX = mousePos.X - tooltipWidth - 10;
            if (tooltipY + tooltipHeight > screenHeight) tooltipY = mousePos.Y - tooltipHeight - 10;

            Image tooltipBg = textures.GetTexture(hoveredModule.TooltipTextureName);
            if (tooltipBg != null)
            {
                g.DrawImage(tooltipBg, tooltipX, tooltipY, tooltipWidth, tooltipHeight);
            }
            else
            {
                g.FillRectangle(Brushes.Gray, tooltipX, tooltipY, tooltipWidth, tooltipHeight);
                g.DrawRectangle(Pens.Black, tooltipX, tooltipY, tooltipWidth, tooltipHeight);
            }

            g.DrawString(hoveredModule.Name, new Font("Arial", 10, FontStyle.Bold), Brushes.White, tooltipX + 5, tooltipY + 5);
            g.DrawString(hoveredModule.Description, new Font("Arial", 9), Brushes.White, new RectangleF(tooltipX + 5, tooltipY + 25, tooltipWidth - 10, tooltipHeight - 30));
        }
    }
}