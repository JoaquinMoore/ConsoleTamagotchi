public class Game
{
    public static bool isRunning = true;

    private static readonly UserInputs s_userInput = new();
    public static Scene currentEscene = new MainMenuScene();

    public static void Main()
    {
        while (isRunning)
        {
            currentEscene.Update();
            s_userInput.Update();
        }
    }
}
