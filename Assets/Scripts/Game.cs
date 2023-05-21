public class Game
{
    public static bool isRunning = true;

    private static readonly UserInputs _userInput = new();
    public static Scene currentEscene;

    public static void Main()
    {
        SceneManager.LoadScenes("MainMenu");

        while (true)
        {
            currentEscene.Update();

            if (!isRunning)
                break;

            currentEscene.Render();
            _userInput.Update();
        }
    }
}
