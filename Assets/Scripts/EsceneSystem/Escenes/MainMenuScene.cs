public class MainMenuScene : Scene, IUpdate
{
    private int _cursorPosition = 0;
    private string[] _sprites = new string[] {
        "MenuSprites/menu_play",
        "MenuSprites/menu_exit"
    };
    private Action[] _options = new Action[] {
        () => SceneManager.LoadScenes("Game"),
        () => Game.isRunning = false
    };

    public override void OnLoad()
    {
        base.OnLoad();

        Console.WriteLine("Cargando el menu...");
    }

    public override void Update()
    {
        // Movimiento de las flechas.
        if (UserInputs.GetKey(ConsoleKey.DownArrow)) MoveCursorDown();
        if (UserInputs.GetKey(ConsoleKey.UpArrow)) MoveCursorUp();
        if (UserInputs.GetKey(ConsoleKey.Enter)) _options[_cursorPosition]();
    }

    public override void Render()
    {
        Renderer.RenderFromFile(_sprites[_cursorPosition]);
    }

    private void ChangeCursorPosition(int newPosition)
    {
        if (newPosition < 0)
            newPosition = _options.Length - 1;
        else if (newPosition > _options.Length - 1)
            newPosition = 0;

        _cursorPosition = newPosition;
    }

    private void MoveCursorUp() => ChangeCursorPosition(_cursorPosition - 1);

    private void MoveCursorDown() => ChangeCursorPosition(_cursorPosition + 1);
}