public class Weapon
{
    public string Model { get; set; }
    public int Damage { get; set; }
    public int Durability { get; set; } // En %
    public int Ammo { get; set; }
    public int Level { get; set; } = 1;
    public int XP { get; set; } = 0;

    public Weapon(string model, int damage, int ammo)
    {
        Model = model;
        Damage = damage;
        Ammo = ammo;
        Durability = 100;
    }

    public void Use()
    {
        Durability -= 5;
        if (Ammo > 0) Ammo--; // On ne baisse les munitions que s'il y en a
        XP += 10;
        if (XP >= 100) LevelUp();
    }

    private void LevelUp()
    {
        Level++;
        XP = 0;
        Damage += 5;
        Console.WriteLine($"✨ Votre {Model} passe au niveau {Level} ! Dégâts augmentés.");
    }
}