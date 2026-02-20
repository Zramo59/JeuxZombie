namespace JeuxZombie;

public class Weapon
{
    public string Model { get; set; }
    public int Damage { get; set; }
    public int Durability { get; set; } // En %
    public int Ammo { get; set; }
    public int Level { get; set; } = 1;
    public int Xp { get; set; }
    public int MaxDurability { get; set; } = 100; // Durabilité maximale

    public Weapon(string model, int damage, int ammo)
    {
        Model = model;
        Damage = damage;
        Ammo = ammo;
        Durability = 100;
    }

    public void Use()
    {
        Durability = Math.Max(0, Durability - 5);
        if (Ammo > 0) Ammo--;
        Xp += 10;
        if (Xp >= 100) LevelUp();
    }

    private void LevelUp()
    {
        Level++;
        Xp = 0;
        Damage += 5;
        Durability = Math.Min(MaxDurability, Durability + 20); // Restaurer 20% de durabilité
        Console.WriteLine($"✨ Votre {Model} passe au niveau {Level} ! Dégâts: +5 (Total: {Damage}), Durabilité restaurée.");
    }

    public int GetCurrentDamage()
    {
        // Les dégâts diminuent avec la durabilité
        return (Durability > 0) ? (Damage * Durability / 100) : 0;
    }

    public bool IsWeaponBroken()
    {
        return Durability <= 0;
    }

    public int CalculateRepairCost()
    {
        // Coût basé sur la dégradation avec une courbe progressive plus douce
        int damagePercentage = MaxDurability - Durability;
        
        // Formule exponentielle pour une augmentation plus progressive
        // damagePercentage: 0-100
        // baseCost: 15 à 0% dégradé, jusqu'à ~500 à 100% dégradé
        double degradationRatio = damagePercentage / 100.0;
        int baseCost = 15 + (int)(Math.Pow(degradationRatio, 1.8) * 485); // Coût plus progressif
        
        // Ajouter une variation aléatoire (±15%)
        Random rng = new Random();
        int variation = rng.Next(-15, 16); // Entre -15 et +15
        int finalCost = Math.Max(10, baseCost + (baseCost * variation / 100)); // Minimum 10 or
        
        return finalCost;
    }

    public bool TryRepair(Player player)
    {
        if (Durability == MaxDurability)
        {
            UIHelper.DisplayWarning("Votre arme est déjà en parfait état !");
            return false;
        }

        int repairCost = CalculateRepairCost();

        if (player.Gold < repairCost)
        {
            UIHelper.DisplayError($"Vous n'avez pas assez d'or ! Coût: {repairCost} or (Vous avez: {player.Gold})");
            return false;
        }

        // Effectuer la réparation
        player.Gold -= repairCost;
        Durability = MaxDurability;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n  ✨ {Model} réparée avec succès !");
        Console.WriteLine($"  💰 Coût de réparation: {repairCost} or");
        Console.WriteLine($"  💸 Or restant: {player.Gold}");
        Console.ResetColor();
        
        return true;
    }

    public void Repair()
    {
        Durability = MaxDurability;
    }

    public void DisplayWeaponInfo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n  ╔════════════════════════════════════════╗");
        Console.WriteLine($"  ║ 🗡️  {Model.PadRight(35)} ║");
        Console.WriteLine($"  ╠════════════════════════════════════════╣");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"  ║ Niveau: {Level.ToString().PadRight(30)} ║");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  ║ Dégâts: {Damage.ToString().PadRight(30)} ║");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"  ║ Dégâts actuels: {GetCurrentDamage().ToString().PadRight(22)} ║");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"  ║ Durabilité: ");
        DisplayDurabilityBar();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"║");
        
        if (Ammo > 0)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"  ║ Munitions: {Ammo.ToString().PadRight(28)} ║");
        }
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"  ║ XP: {Xp.ToString()}/100{new string(' ', 24)} ║");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"  ╚════════════════════════════════════════╝\n");
        Console.ResetColor();
    }

    private void DisplayDurabilityBar()
    {
        int barLength = 20;
        int filledLength = (Durability * barLength) / 100;
        
        Console.ForegroundColor = (Durability > 50) ? ConsoleColor.Green : 
                                   (Durability > 25) ? ConsoleColor.Yellow : ConsoleColor.Red;
        
        Console.Write("[");
        Console.Write(new string('█', filledLength));
        Console.Write(new string('░', barLength - filledLength));
        Console.Write($"] {Durability}%");
        Console.ResetColor();
    }
}