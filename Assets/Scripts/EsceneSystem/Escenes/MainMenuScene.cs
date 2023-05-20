public class MainMenuScene : Scene, IUpdate
{
    private int _cursorPosition = 0;
    private string[] _sprites = new string[]
    {
        "MenuSprites/menu_play",
        "MenuSprites/menu_exit"
    };

    public override void Update()
    {
        Renderer.RenderFromFile(_sprites[_cursorPosition]);

        // Movimiento de las flechas.
        if (UserInputs.GetKey(ConsoleKey.DownArrow)) MoveCursorDown();
        if (UserInputs.GetKey(ConsoleKey.UpArrow)) MoveCursorUp();
        Console.WriteLine(_cursorPosition);
    }

    private void ChangeCursorPosition(int newPosition)
    {
        //if (newPosition < 0)
        //    newPosition = options.Length - 1;
        //else if (newPosition > options.Length - 1)
        //    newPosition = 0;

        //_cursorPosition = newPosition;
    }

    private void MoveCursorUp() => ChangeCursorPosition(_cursorPosition - 1);
    private void MoveCursorDown() => ChangeCursorPosition(_cursorPosition + 1);
}