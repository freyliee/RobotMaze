namespace RobotMaze;

public class TextureManager
{
    private Dictionary<string, Image> cache = new Dictionary<string, Image>();

    public Image GetTexture(string name)
    {
        if (cache.ContainsKey(name))
        {
            return cache[name];
        }

        string path = Path.Combine("Assets", "Textures", name);
        if (File.Exists(path))
        {
            Image img = Image.FromFile(path);
            cache[name] = img;
            return img;
        }

        return null;
    }
}
