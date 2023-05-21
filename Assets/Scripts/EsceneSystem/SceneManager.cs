public class SceneManager
{
    private static Dictionary<string, Func<Scene>> _scenes = new(){
        {"Game", () => new GameScene()},
        {"MainMenu", () => new MainMenuScene()}
    };

    public static void LoadScenes(string name)
    {
        Game.currentEscene = _scenes[name]();
    }
}