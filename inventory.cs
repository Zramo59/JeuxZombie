using System;
using System.Collections.Generic;
using System.Linq;

public enum PotionType { Petite, Moyenne, Grande }

public class Potion
{
    public string Name { get; set; }
    public int HealAmount { get; set; }
    public PotionType Type { get; set; }

    public Potion(PotionType type)
    {
        Type = type;
        switch (type)
        {
            case PotionType.Petite:
                Name = "Petite Potion";
                HealAmount = 25;
                break;
            case PotionType.Moyenne:
                Name = "Potion Moyenne";
                HealAmount = 50;
                break;
            case PotionType.Grande:
                Name = "Grande Potion";
                HealAmount = 100;
                break;
        }
    }
}

public class Inventory
{
    private List<Potion> _potions;
    private int _maxCapacity;

    public Inventory(int maxCapacity = 5)
    {
        _maxCapacity = maxCapacity;
        _potions = new List<Potion>();
    }

    public int Count => _potions.Count;
    public bool IsFull => _potions.Count >= _maxCapacity;
    public bool IsEmpty => _potions.Count == 0;

    public bool AddPotion(Potion potion)
    {
        if (IsFull)
        {
            Console.WriteLine("❌ Inventaire plein ! Impossible d'ajouter une potion.");
            return false;
        }

        _potions.Add(potion);
        Console.WriteLine($"✓ {potion.Name} ajoutée à l'inventaire. ({Count}/{_maxCapacity})");
        return true;
    }

    public Potion GetPotion(PotionType type)
    {
        var potion = _potions.FirstOrDefault(p => p.Type == type);
        if (potion != null)
        {
            _potions.Remove(potion);
        }
        return potion;
    }

    public Potion GetAnyPotion()
    {
        if (IsEmpty) return null;
        
        var potion = _potions[0];
        _potions.RemoveAt(0);
        return potion;
    }

    public void DisplayInventory()
    {
        Console.WriteLine($"\n=== INVENTAIRE ({Count}/{_maxCapacity}) ===");
        if (IsEmpty)
        {
            Console.WriteLine("  Vide");
            return;
        }

        var grouped = _potions.GroupBy(p => p.Type).OrderBy(g => g.Key);
        int index = 1;
        foreach (var group in grouped)
        {
            Console.WriteLine($"  {index}. {group.First().Name} (+{group.First().HealAmount} PV) x{group.Count()}");
            index++;
        }
    }

    public List<Potion> GetAllPotions()
    {
        return new List<Potion>(_potions);
    }

    public bool HasPotion(PotionType type)
    {
        return _potions.Any(p => p.Type == type);
    }

    public bool HasAnyPotion()
    {
        return !IsEmpty;
    }
}
