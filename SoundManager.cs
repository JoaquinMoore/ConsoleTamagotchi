public enum Notes
{
    Do = 261,
    DoS = 277,
    Re = 293,
    ReS = 311,
    Mi = 329,
    Fa = 349,
    FaS = 370,
    Sol = 392,
    SolS = 415,
    La = 440,
    LaS = 466,
    Si = 493,
}

public class SoundManager
{
    public static void PlaySound(Notes note, int octaves = 1, int duration = 500)
    {
        Console.Beep((int)note * octaves, duration);
    }
}
