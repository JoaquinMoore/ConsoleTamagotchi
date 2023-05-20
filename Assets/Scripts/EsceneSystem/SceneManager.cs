public class SceneManager
{
    public static void ExitGame() => Game.isRunning = false;

    public static void Play()
    {
        if (Game.currentEscene.GetType() == typeof(GameScene))
            return;

        Game.currentEscene = new GameScene();
    }
}