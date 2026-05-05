using System.Data;
using Timer = System.Windows.Forms.Timer;

namespace RobotMaze;

public partial class GameForm : Form
{
    private readonly Timer timer;
    private Game game;
    
    public GameForm(LevelData level, int levelIndex)
    {
        InitializeComponent();
        
        FormBorderStyle = FormBorderStyle.None;
        WindowState = FormWindowState.Maximized;
        
        game = new Game(level);
        game.OnGoalReached += () =>
        {
            timer.Stop();
            if (LevelManager.UnlockedLevelIndex <= levelIndex)
            {
                LevelManager.UnlockedLevelIndex = levelIndex + 1;
            }
            
            LevelSelectForm levelSelect = new LevelSelectForm();
            levelSelect.ApplyState(this);
            levelSelect.Show();
            this.Hide();
        };
        
        KeyPreview = true;
        
        timer = new Timer();
        timer.Interval = 16;
        timer.Tick += (s, e) =>
        {
            game.Update();
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
                    this.Hide();
                };
                popup.Controls.Add(exitBtn);

                Button resumeBtn = new Button();
                resumeBtn.Text = "Возобновить игру";
                resumeBtn.Size = new Size(120, 23);
                resumeBtn.Location = new Point(140, 80);
                resumeBtn.Click += (s2, e2) => {
                    Controls.Remove(popup);
                    timer.Start();
                    this.Focus();
                };
                popup.Controls.Add(resumeBtn);

                Controls.Add(popup);
                popup.BringToFront();
                timer.Stop();
            }

            game.HandleKey(e.KeyCode);
        };
        
        FormClosed += (s, e) => Application.Exit();
        
        DoubleBuffered = true;
    }

    public void ApplyState(Form other)
    {
        this.WindowState = other.WindowState;
        this.FormBorderStyle = other.FormBorderStyle;
        if (this.WindowState == FormWindowState.Normal)
        {
            this.Size = other.Size;
            this.Location = other.Location;
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
        game.Draw(e.Graphics);
    }
}