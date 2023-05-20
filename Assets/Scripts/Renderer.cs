public class Renderer
{
    public const string PATH = "D:\\Proyectos\\ConsoleTamagotchi\\Assets\\";

    public static void Render(string text)
    {
        Console.Clear();
        Console.WriteLine(text);
    }

    public static void RenderFromFile(string fileName)
    {
        Render(LoadFile(fileName));
    }

    public static string LoadFile(string fileName)
    {
        string file = PATH + fileName + ".txt";
        return File.ReadAllText(file);
    }
}
