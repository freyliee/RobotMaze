using Timer = System.Windows.Forms.Timer;

namespace RobotMaze;

public partial class GameForm : Form
{
    private readonly Timer timer;
    private Game game;
    
    public GameForm()
    {
        InitializeComponent();
        
        game = new Game();
        
        timer = new Timer();
        timer.Interval = 16;
        timer.Tick += (s, e) =>
        {
            game.Update();
            if (!IsDisposed) Invalidate();
        };
        timer.Start();

        this.KeyDown += (s, e) =>
        {
            game.HandleKey(e.KeyCode);
        };
        
        this.DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        game.Draw(e.Graphics);
    }
}