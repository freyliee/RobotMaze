using RobotMaze.Model.RobotModules;
using Timer = System.Windows.Forms.Timer;

namespace RobotMaze.View;

using Model;
using Controller;

public partial class GameForm : Form
{
    private readonly Timer timer;
    private Game game;
    private GameController controller;
    private GameView view;
    
    private IRobotModule draggingModule = null;
    private IRobotModule hoveredModule = null;
    private Point mousePos = default;

    public GameForm(LevelData level, int levelIndex)
    {
        InitializeComponent();
        
        FormBorderStyle = FormBorderStyle.None;
        WindowState = FormWindowState.Maximized;
        
        game = new Game(level);
        controller = new GameController(game);
        view = new GameView();
        
        game.OnGoalReached += () =>
        {
            timer.Stop();
            if (LevelManager.UnlockedLevelIndex <= levelIndex)
            {
                LevelManager.UnlockedLevelIndex = levelIndex + 1;
            }
            if (LevelManager.CompletedLevelIndex < levelIndex)
            {
                LevelManager.CompletedLevelIndex = levelIndex;
            }

            ShowResultPopup("Уровень пройден!", "Следующий уровень", () =>
            {
                var levels = LevelManager.GetLevels();
                if (levelIndex + 1 < levels.Count)
                {
                    GameForm nextGame = new GameForm(levels[levelIndex + 1], levelIndex + 1);
                    nextGame.ApplyState(this);
                    nextGame.Show();
                    Hide();
                }
                else
                {
                    LevelSelectForm levelSelect = new LevelSelectForm();
                    levelSelect.ApplyState(this);
                    levelSelect.Show();
                    Hide();
                }
            });
        };

        game.OnGameOver += () =>
        {
            timer.Stop();
            ShowResultPopup("Игра окончена!", "Попробовать ещё", () =>
            {
                GameForm restartGame = new GameForm(level, levelIndex);
                restartGame.ApplyState(this);
                restartGame.Show();
                Hide();
            });
        };
        
        KeyPreview = true;
        
        timer = new Timer();
        timer.Interval = 16;
        timer.Tick += (s, e) =>
        {
            controller.Update();
            if (!IsDisposed) Invalidate();
        };
        timer.Start();

        KeyDown += (s, e) =>
        {
            if (Controls.OfType<Panel>().Any(p => p.BorderStyle == BorderStyle.FixedSingle))
            {
                return;
            }

            if (e.KeyCode == Keys.F11)
            {
                if (FormBorderStyle == FormBorderStyle.None)
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    Size = new Size(1280, 720);
                    Location = new Point((Screen.PrimaryScreen.Bounds.Width - 1280) / 2, (Screen.PrimaryScreen.Bounds.Height - 720) / 2);
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                Panel popup = new Panel();
                popup.Size = new Size(300, 150);
                popup.BackColor = Color.LightGray;
                popup.BorderStyle = BorderStyle.FixedSingle;
                popup.Location = new Point((Width - popup.Width) / 2, (Height - popup.Height) / 2);

                Label question = new Label();
                question.Text = "Точно ли вы хотите выйти?";
                question.AutoSize = true;
                question.Location = new Point(50, 30);
                popup.Controls.Add(question);

                Button exitBtn = new Button();
                exitBtn.Text = "Выйти";
                exitBtn.Location = new Point(40, 80);
                exitBtn.Click += (s2, e2) => {
                    LevelSelectForm levelSelect = new LevelSelectForm();
                    levelSelect.ApplyState(this);
                    levelSelect.Show();
                    Hide();
                };
                popup.Controls.Add(exitBtn);

                Button resumeBtn = new Button();
                resumeBtn.Text = "Возобновить игру";
                resumeBtn.Size = new Size(120, 23);
                resumeBtn.Location = new Point(140, 80);
                resumeBtn.Click += (s2, e2) => {
                    Controls.Remove(popup);
                    timer.Start();
                    Focus();
                };
                popup.Controls.Add(resumeBtn);

                Controls.Add(popup);
                popup.BringToFront();
                timer.Stop();
            }

            // game.HandleKey(e.KeyCode);
        };
        
        FormClosed += (s, e) => Application.Exit();
        
        DoubleBuffered = true;

        int dragSourceIdx = -1; 
        bool isFromAvailable = false;

        MouseDown += (s, e) =>
        {
            if (game.IsExecuting) return;
            float screenWidth = Width;
            float screenHeight = Height;
            float leftPanelWidth = screenWidth * 0.15f;
            float bottomPanelHeight = screenHeight * 0.15f;

            float moduleBoxSize = leftPanelWidth * 0.4f;
            for (int i = 0; i < game.AvailableModules.Count; i++)
            {
                int col = i % 2;
                int row = i / 2;
                float moduleBoxX = (leftPanelWidth / 2 - moduleBoxSize) / 2 + col * (leftPanelWidth / 2);
                float y = 50 + row * (moduleBoxSize + 10);
                if (e.X >= moduleBoxX && e.X <= moduleBoxX + moduleBoxSize && e.Y >= y && e.Y <= y + moduleBoxSize)
                {
                    draggingModule = game.AvailableModules[i];
                    dragSourceIdx = i;
                    isFromAvailable = true;
                    mousePos = e.Location;
                    return;
                }
            }

            float slotSize = bottomPanelHeight * 0.8f;
            float slotsTotalWidth = game.Robot.Modules.Length * slotSize + (game.Robot.Modules.Length - 1) * 10;
            float slotsStartX = (screenWidth - slotsTotalWidth) / 2;
            float slotsStartY = screenHeight - bottomPanelHeight + (bottomPanelHeight - slotSize) / 2;

            for (int i = 0; i < game.Robot.Modules.Length; i++)
            {
                float x = slotsStartX + i * (slotSize + 10);
                if (e.X >= x && e.X <= x + slotSize && e.Y >= slotsStartY && e.Y <= slotsStartY + slotSize)
                {
                    if (game.Robot.Modules[i] != null)
                    {
                        draggingModule = game.Robot.Modules[i];
                        dragSourceIdx = i;
                        isFromAvailable = false;
                        mousePos = e.Location;
                    }
                    return;
                }
            }

            float runBtnWidth = 100;
            float runBtnHeight = 50;
            float runBtnX = screenWidth - runBtnWidth - 20;
            float runBtnY = screenHeight - runBtnHeight - 20;
            if (e.X >= runBtnX && e.X <= runBtnX + runBtnWidth && e.Y >= runBtnY && e.Y <= runBtnY + runBtnHeight)
            {
                controller.StartExecution();
            }

            float restartBtnWidth = 100;
            float restartBtnHeight = 40;
            float restartBtnX = Width - restartBtnWidth - 20;
            float restartBtnY = 20;
            if (e.X >= restartBtnX && e.X <= restartBtnX + restartBtnWidth && e.Y >= restartBtnY && e.Y <= restartBtnY + restartBtnHeight)
            {
                GameForm restartGame = new GameForm(level, levelIndex);
                restartGame.ApplyState(this);
                restartGame.Show();
                Hide();
            }
        };

        MouseMove += (s, e) =>
        {
            if (game.IsExecuting) return;
            mousePos = e.Location;
            if (draggingModule != null)
            {
                hoveredModule = null;
                Invalidate();
            }
            else
            {
                IRobotModule lastHovered = hoveredModule;
                hoveredModule = null;

                float screenWidth = Width;
                float screenHeight = Height;
                float leftPanelWidth = screenWidth * 0.15f;
                float bottomPanelHeight = screenHeight * 0.15f;

                float moduleBoxSize = leftPanelWidth * 0.4f;
                for (int i = 0; i < game.AvailableModules.Count; i++)
                {
                    int col = i % 2;
                    int row = i / 2;
                    float moduleBoxX = (leftPanelWidth / 2 - moduleBoxSize) / 2 + col * (leftPanelWidth / 2);
                    float y = 50 + row * (moduleBoxSize + 10);
                    if (e.X >= moduleBoxX && e.X <= moduleBoxX + moduleBoxSize && e.Y >= y && e.Y <= y + moduleBoxSize)
                    {
                        hoveredModule = game.AvailableModules[i];
                        break;
                    }
                }

                if (hoveredModule == null)
                {
                    float slotSize = bottomPanelHeight * 0.8f;
                    float slotsTotalWidth = game.Robot.Modules.Length * slotSize + (game.Robot.Modules.Length - 1) * 10;
                    float slotsStartX = (screenWidth - slotsTotalWidth) / 2;
                    float slotsStartY = screenHeight - bottomPanelHeight + (bottomPanelHeight - slotSize) / 2;

                    for (int i = 0; i < game.Robot.Modules.Length; i++)
                    {
                        float x = slotsStartX + i * (slotSize + 10);
                        if (e.X >= x && e.X <= x + slotSize && e.Y >= slotsStartY && e.Y <= slotsStartY + slotSize)
                        {
                            hoveredModule = game.Robot.Modules[i];
                            break;
                        }
                    }
                }

                if (hoveredModule != lastHovered)
                {
                    Invalidate();
                }
            }
        };

        MouseUp += (s, e) =>
        {
            if (draggingModule == null) return;

            float screenWidth = Width;
            float screenHeight = Height;
            controller.HandleDragAndDrop(draggingModule, dragSourceIdx, isFromAvailable, e.Location, Size);
            
            draggingModule = null;
            Invalidate();
        };
    }

    public void ApplyState(Form other)
    {
        WindowState = other.WindowState;
        FormBorderStyle = other.FormBorderStyle;
        if (WindowState == FormWindowState.Normal)
        {
            Size = other.Size;
            Location = other.Location;
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        foreach (Control c in Controls)
        {
            if (c is Panel popup && popup.BorderStyle == BorderStyle.FixedSingle)
            {
                popup.Location = new Point((Width - popup.Width) / 2, (Height - popup.Height) / 2);
            }
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        view.Draw(e.Graphics, game, draggingModule, hoveredModule, mousePos);
    }

    private void ShowResultPopup(string message, string mainActionText, Action mainAction)
    {
        Panel popup = new Panel();
        popup.Size = new Size(300, 150);
        popup.BackColor = Color.LightGray;
        popup.BorderStyle = BorderStyle.FixedSingle;
        popup.Location = new Point((Width - popup.Width) / 2, (Height - popup.Height) / 2);

        Label lbl = new Label();
        lbl.Text = message;
        lbl.AutoSize = true;
        lbl.Location = new Point(100, 30);
        popup.Controls.Add(lbl);

        Button mainBtn = new Button();
        mainBtn.Text = mainActionText;
        mainBtn.AutoSize = true;
        mainBtn.Location = new Point(20, 80);
        mainBtn.Click += (s, e) => mainAction();
        popup.Controls.Add(mainBtn);

        Button menuBtn = new Button();
        menuBtn.Text = "В главное меню";
        menuBtn.AutoSize = true;
        menuBtn.Location = new Point(155, 80);
        menuBtn.Click += (s, e) =>
        {
            MainMenuForm menu = new MainMenuForm();
            menu.ApplyState(this);
            menu.Show();
            Hide();
        };
        popup.Controls.Add(menuBtn);

        Controls.Add(popup);
        popup.BringToFront();
    }
}