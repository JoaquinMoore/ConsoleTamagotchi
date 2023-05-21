using Timer = System.Threading.Timer;

public sealed class GameScene : Scene
{
    private Pet pet;
    private Timer hungerTime;

    public GameScene()
    {
        pet = new Pet("Pepe");
        hungerTime = new Timer(x => pet.SetFoodLvl(pet.FoodLvl - 1), null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        new Thread(Prueba).Start();
    }

    public override void Render()
    {
        Renderer.Render(pet.Sprite);
    }

    public void Prueba()
    {
        Renderer.Render("Hola");
        Console.WriteLine("Sas");
    }
    public override void Update()
    {
        // Renderer.Render(pet.FoodLvl.ToString());
    }
}