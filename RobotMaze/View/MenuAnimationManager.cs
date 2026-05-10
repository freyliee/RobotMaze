using RobotMaze.Model;

namespace RobotMaze.View;

public class MenuAnimationManager
{
    public class MenuRobot
    {
        public float X;
        public float Y;
        public float Speed;
        public int Direction;
    }

    private static MenuAnimationManager instance;
    public static MenuAnimationManager Instance => instance ??= new MenuAnimationManager();

    public readonly List<MenuRobot> Robots = new();
    private readonly Random random = new();
    private int spawnTimer = 0;
    private int width;
    private int height;
    private DateTime lastUpdate = DateTime.Now;

    private MenuAnimationManager() { }

    public void Update(int currentWidth, int currentHeight)
    {
        var now = DateTime.Now;
        if ((now - lastUpdate).TotalMilliseconds < 10) return;
        lastUpdate = now;

        width = currentWidth;
        height = currentHeight;

        spawnTimer++;
        if (spawnTimer >= 30 && Robots.Count < 15 && spawnTimer % 15 == 0)
        {
            Robots.Add(CreateRandomRobot());
        }

        for (int i = 0; i < Robots.Count; i++)
        {
            var r = Robots[i];
            if (r.Direction == 0) r.Y -= r.Speed;
            else if (r.Direction == 1) r.X += r.Speed;
            else if (r.Direction == 2) r.Y += r.Speed;
            else if (r.Direction == 3) r.X -= r.Speed;

            if (r.X < -100 || r.X > width + 100 || r.Y < -100 || r.Y > height + 100)
            {
                Robots[i] = CreateRandomRobot();
            }
        }
    }

    private MenuRobot CreateRandomRobot()
    {
        int direction = random.Next(4);
        float speed = (float)(random.NextDouble() * 2 + 1);
        float x = 0, y = 0;

        if (direction == 0) { x = random.Next(width); y = height + 50; }
        else if (direction == 1) { x = -50; y = random.Next(height); }
        else if (direction == 2) { x = random.Next(width); y = -50; }
        else if (direction == 3) { x = width + 50; y = random.Next(height); }

        return new MenuRobot { X = x, Y = y, Speed = speed, Direction = direction };
    }

    public void Draw(Graphics g, TextureManager textureManager, int width, int height)
    {
        Image grassTexture = textureManager.GetTexture("grass.png");
        if (grassTexture != null)
        {
            using (TextureBrush grassBrush = new TextureBrush(grassTexture))
            {
                g.FillRectangle(grassBrush, 0, 0, width, height);
            }
        }
        else
        {
            g.Clear(Color.FromArgb(255, 100, 200, 100));
        }

        Image robotTexture = textureManager.GetTexture("robot.png");
        float robotSize = 60;

        foreach (var r in Robots)
        {
            if (robotTexture != null)
            {
                var state = g.Save();
                g.TranslateTransform(r.X, r.Y);
                g.RotateTransform(r.Direction * 90 + 180);
                g.DrawImage(robotTexture, -robotSize / 2, -robotSize / 2, robotSize, robotSize);
                g.Restore(state);
            }
            else
            {
                g.FillRectangle(Brushes.Blue, r.X - robotSize / 2, r.Y - robotSize / 2, robotSize, robotSize);
            }
        }
    }
}
