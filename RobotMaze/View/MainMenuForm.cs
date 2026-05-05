namespace RobotMaze.View;

public class MainMenuForm : Form
{
    public MainMenuForm()
    {
        FormBorderStyle = FormBorderStyle.None;
        WindowState = FormWindowState.Maximized;
        BackColor = Color.White;
        DoubleBuffered = true;
        KeyPreview = true;

        Label title = new Label();
        title.Text = "RobotMaze";
        title.ForeColor = Color.Black;
        title.Font = new Font("Arial", 48, FontStyle.Bold);
        title.AutoSize = true;
        title.Location = new Point((Width - title.Width) / 2, Height / 4);
        Controls.Add(title);

        Button playButton = new Button();
        playButton.Text = "Играть";
        playButton.Size = new Size(200, 50);
        playButton.Location = new Point((Width - playButton.Width) / 2, Height / 2);
        playButton.Click += (s, e) => {
            LevelSelectForm levelSelect = new LevelSelectForm();
            levelSelect.ApplyState(this);
            levelSelect.Show();
            Hide();
        };
        Controls.Add(playButton);

        Button exitButton = new Button();
        exitButton.Text = "Выход";
        exitButton.Size = new Size(200, 50);
        exitButton.Location = new Point((Width - exitButton.Width) / 2, Height / 2 + 70);
        exitButton.Click += (s, e) => Application.Exit();
        Controls.Add(exitButton);

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
                Application.Exit();
            }
        };

        FormClosed += (s, e) => Application.Exit();
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

        foreach (Control c in Controls)
        {
            if (c is Label l)
            {
                l.Font = new Font("Arial", 48 * scale, FontStyle.Bold);
                l.Location = new Point((Width - l.Width) / 2, Height / 4);
            }
            if (c is Button b)
            {
                b.Size = new Size((int)(200 * scale), (int)(50 * scale));
                b.Font = new Font("Arial", 12 * scale);
                if (b.Text == "Играть") b.Location = new Point((Width - b.Width) / 2, Height / 2);
                if (b.Text == "Выход") b.Location = new Point((Width - b.Width) / 2, Height / 2 + b.Height + 20);
            }
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        CenterElements();
    }
}
