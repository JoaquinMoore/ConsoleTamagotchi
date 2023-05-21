public class Pet
{
    private string _name;
    private int maxFood = 100;
    private int maxHealth = 100;
    private int health;

    public int FoodLvl { get; private set; }
    public string Sprite => Renderer.LoadFile("PetSprites/pet_idle");

    public Pet(string name)
    {
        name = name;
        health = maxHealth;
        SetFoodLvl(maxFood / 2);
    }

    public void SetFoodLvl(int amount)
    {
        FoodLvl = amount;
    }
}