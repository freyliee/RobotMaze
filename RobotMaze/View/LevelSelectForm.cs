using RobotMaze.Model;
using Timer = System.Windows.Forms.Timer;

namespace RobotMaze.View;

public class LevelSelectForm : Form
{
    private TextureManager textureManager;
    private readonly Timer animationTimer;

    public LevelSelectForm()
    {
        AudioManager.StopBackgroundMusic();
        FormBorderStyle = FormBorderStyle.None;
        WindowState = FormWindowState.Maximized;
        BackColor = Color.DarkSlateBlue;
        DoubleBuffered = true;
        KeyPreview = true;
        textureManager = new TextureManager();

        animationTimer = new Timer();
        animationTimer.Interval = 16;
        animationTimer.Tick += (s, e) =>
        {
            MenuAnimationManager.Instance.Update(Width, Height);
            Invalidate();
        };
        animationTimer.Start();

        List<LevelData> allLevels = LevelManager.GetLevels();
        string[] levelNames = { "Обучение", "Уровень 1", "Уровень 2", "Уровень 3", "Уровень 4", "Уровень 5" };
        
        for (int i = 0; i < levelNames.Length; i++)
        {
            Button btn = new Button();
            btn.Text = levelNames[i];
            btn.Size = new Size(150, 150);
            btn.Location = new Point(0, 0);

            LevelData levelData = allLevels.Count > i ? allLevels[i] : null;
            int currentIdx = i;
            
            if (i > LevelManager.UnlockedLevelIndex || levelData == null)
            {
                btn.Enabled = false;
                btn.BackColor = Color.FromArgb(150, Color.Gray);
                btn.FlatStyle = FlatStyle.Flat;
                Image lockImg = textureManager.GetTexture("lock.png");
                if (lockImg != null) btn.Image = lockImg;
            }
            else if (i <= LevelManager.CompletedLevelIndex)
            {
                btn.BackColor = Color.FromArgb(200, Color.LightGreen);
                btn.FlatStyle = FlatStyle.Flat;
                Image levelImg = textureManager.GetTexture("level" + i + ".png");
                if (levelImg != null) btn.Image = levelImg;
            }
            else
            {
                btn.BackColor = Color.FromArgb(200, Color.LightSkyBlue);
                btn.FlatStyle = FlatStyle.Flat;
                Image levelImg = textureManager.GetTexture("level" + i + ".png");
                if (levelImg != null) btn.Image = levelImg;
            }

            btn.Click += (s, e) => {
                if (levelData != null)
                {
                    GameForm gameForm = new GameForm(levelData, currentIdx);
                    gameForm.ApplyState(this);
                    gameForm.Show();
                    Hide();
                }
            };

            Controls.Add(btn);
        }

        Button backButton = new Button();
        backButton.Text = "Назад";
        backButton.ForeColor = Color.Black;
        backButton.BackColor = Color.White;
        backButton.FlatStyle = FlatStyle.Flat;
        backButton.Size = new Size(100, 40);
        backButton.Location = new Point(50, 50);
        backButton.Click += (s, e) => {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.ApplyState(this);
            mainMenu.Show();
            Hide();
        };
        Controls.Add(backButton);

        KeyDown += (s, e) => {
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
                MainMenuForm mainMenu = new MainMenuForm();
                mainMenu.ApplyState(this);
                mainMenu.Show();
                Hide();
            }
        };

        FormClosed += (s, e) =>
        {
            animationTimer.Stop();
            animationTimer.Dispose();
            Application.Exit();
        };
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        MenuAnimationManager.Instance.Draw(e.Graphics, textureManager, Width, Height);
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
        CenterElements();
    }

    private void CenterElements()
    {
        float scale = Math.Min(Width / 1920f, Height / 1080f);
        if (scale < 0.5f) scale = 0.5f;

        int btnSize = (int)(150 * scale);
        int spacing = (int)(50 * scale);
        int totalWidth = 3 * btnSize + 2 * spacing;
        int totalHeight = 2 * btnSize + spacing;

        int startX = (Width - totalWidth) / 2;
        int startY = (Height - totalHeight) / 2;

        int btnIdx = 0;
        foreach (Control c in Controls)
        {
            if (c is Button b)
            {
                if (b.Text != "Назад")
                {
                    b.Size = new Size(btnSize, btnSize);
                    b.Font = new Font("Arial", 10 * scale);
                    b.Location = new Point(startX + (btnIdx % 3) * (btnSize + spacing), startY + (btnIdx / 3) * (btnSize + spacing));
                    btnIdx++;
                }
                else
                {
                    b.Size = new Size((int)(100 * scale), (int)(40 * scale));
                    b.Font = new Font("Arial", 8 * scale);
                    b.Location = new Point(20, 20);
                }
            }
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        CenterElements();
    }
}
