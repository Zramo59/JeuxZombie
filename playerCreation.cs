using System;
using System.Collections.Generic;

public enum PlayerType { Tank, Chevalier, Mage }

public class Player
{
    public string Name { get; set; }
    public PlayerType Type { get; set; }
    public int Health { get; set; }
    public Weapon CurrentWeapon { get; set; }
    public string Description { get; set; }
    public Inventory Inventory { get; set; }

    public Player(string name, PlayerType type)
    {
        Name = name;
        InitialisePlayer(type);
        Inventory = new Inventory(5);
        
        // Ajouter quelques potions de départ
        Inventory.AddPotion(new Potion(PotionType.Petite));
        Inventory.AddPotion(new Potion(PotionType.Petite));
        Inventory.AddPotion(new Potion(PotionType.Moyenne));
    }

    private void InitialisePlayer(PlayerType type)
    {
        Type = type;
        switch (type)
        {
            case PlayerType.Tank:
                Health = 200;
                CurrentWeapon = new Weapon("Hache de guerre", 15, 0);
                Description = "Un guerrier robuste, spécialisé dans la défense et le combat rapproché.";
                break;
            case PlayerType.Chevalier:
                Health = 120;
                CurrentWeapon = new Weapon("Épée longue", 25, 0);
                Description = "Un combattant équilibré, alliant force et agilité avec une épée polyvalente.";
                break;
            case PlayerType.Mage:
                Health = 75;
                CurrentWeapon = new Weapon("Bâton magique", 10, 50);
                Description = "Un utilisateur de magie puissant, capable d'infliger des dégâts à distance avec des sorts.";
                break;
        }
    }
}

public class Potion
{
    public string Name { get; set; }
    public int HealAmount { get; set; }
}

public class Inventory
{
    private List<Potion> potions;
    private int capacity;

    public Inventory(int capacity)
    {
        this.capacity = capacity;
        potions = new List<Potion>(capacity);
    }

    public bool AddPotion(Potion potion)
    {
        if (potions.Count < capacity)
        {
            potions.Add(potion);
            return true;
        }
        else
        {
            Console.WriteLine("Inventaire plein, impossible d'ajouter la potion.");
            return false;
        }
    }
}
