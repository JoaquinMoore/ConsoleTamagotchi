public class UserInputs : IUpdate
{
    private static ConsoleKeyInfo _lastKeyPressed;

    public static bool GetKey(ConsoleKey key)
    {
        return key == _lastKeyPressed.Key;
    }

    public void Update()
    {
        _lastKeyPressed = Console.ReadKey();
    }
}