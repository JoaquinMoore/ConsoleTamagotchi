public sealed class GameScene : Scene
{
    private Pet pet;
    private Timer hungerTime;

    public GameScene()
    {
        pet = new Pet("Pepe");
        hungerTime = new Timer(x => pet.SetFoodLvl(pet.FoodLvl - 1), null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
    }

    public override void Update()
    {
        Renderer.Render(pet.Sprite);
        Renderer.Render(pet.FoodLvl.ToString());
    }
}