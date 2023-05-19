public class Tamagotchi
{
    public static void Main()
    {
        _ = new Game();
    }
}

/// <summary>
/// El juego en si.
/// </summary>
public class Game
{
    private bool _running = true;
    private UserInputs _inputs = new();
    private MainMenu _menu = new();
    private Pet _pet = new();
    private RenderObj _currentScene;

    public Game()
    {
        _menu.ExitEvent += ExitGame;
        _menu.PlayEvent += Play;
        _currentScene = _menu;
        MainLoop();
    }

    /// <summary>
    /// El loop principal del juego.
    /// </summary>
    private void MainLoop()
    {
        while (_running)
        {
            _currentScene.Render();
            _inputs.Update();
        }
    }

    private void Play()
    {
        _currentScene = _pet;
    }

    /// <summary>
    /// Sale del juego.
    /// </summary>
    private void ExitGame() => _running = false;
}

public class MainMenu : RenderObj
{
    #region CONSTS
    private const string TITLE = "||| TAMAGOTCHI |||";
    private const char CURSOR = '<';
    #endregion

    #region EVENTS
    public event Action PlayEvent = delegate { };
    public event Action ExitEvent = delegate { };
    #endregion

    private int _cursorPosition = 0;
    private Dictionary<string, Action> _menuOptions = new();

    public MainMenu()
    {
        _menuOptions.Add("Play", () => PlayEvent());
        _menuOptions.Add("Exit", () => ExitEvent());

        UserInputs.DownKey += () => MoveCursor(1);
        UserInputs.UpKey += () => MoveCursor(-1);
        UserInputs.ReturnKey += () => _menuOptions.ElementAt(_cursorPosition).Value.Invoke();
    }

    public override void Render()
    {
        base.Render();

        Console.WriteLine(TITLE);
        Console.WriteLine();

        for (int i = 0; i < _menuOptions.Count; i++)
        {
            var option = _menuOptions.Keys.ElementAt(i);

            if (_cursorPosition == i)
                option += $" {CURSOR}";

            Console.WriteLine("||| " + option);
        }
    }

    /// <summary>
    /// Mueve el cursor.
    /// </summary>
    private void MoveCursor(int steps)
    {
        var newPosition = _cursorPosition + steps;

        if (newPosition < 0)
            newPosition = _menuOptions.Count - 1;
        else if (newPosition > _menuOptions.Count - 1)
            newPosition = 0;

        _cursorPosition = newPosition;
    }
}

public abstract class RenderObj
{
    public virtual void Render()
    {
        Console.Clear();
    }
}

#region USER INPUTS
/// <summary>
/// Llama a eventos de las teclas presionadas.
/// </summary>
public class UserInputs : IUpdate
{
    public static event Action ExitKey = delegate { };
    public static event Action DownKey = delegate { };
    public static event Action UpKey = delegate { };
    public static event Action ReturnKey = delegate { };

    public void Update()
    {
        var keyPressed = Console.ReadKey();
        switch (keyPressed.Key)
        {
            case ConsoleKey.Escape:
                ExitKey();
                break;

            case ConsoleKey.DownArrow:
                DownKey();
                break;

            case ConsoleKey.UpArrow:
                UpKey();
                break;

            case ConsoleKey.Enter:
                ReturnKey();
                break;
        }
    }
}
#endregion

#region INTERFACES
/// <summary>
/// Esta interfaz es para los objetos que se actualizan cada frame.
/// </summary>
public interface IUpdate
{
    void Update();
}
#endregion