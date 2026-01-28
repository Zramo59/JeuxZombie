using System;

public class HealthManager
{
    public static bool UsePotion(Player player, PotionType? potionType = null)
    {
        if (player.Inventory.IsEmpty)
        {
            Console.WriteLine("❌ Aucune potion disponible dans l'inventaire !");
            return false;
        }

        // Récupérer la potion
        Potion potion;
        if (potionType.HasValue)
        {
            potion = player.Inventory.GetPotion(potionType.Value);
            if (potion == null)
            {
                Console.WriteLine($"❌ Aucune potion de type {potionType.Value} disponible !");
                return false;
            }
        }
        else
        {
            potion = player.Inventory.GetAnyPotion();
        }

        return ApplyPotion(player, potion);
    }

    private static bool ApplyPotion(Player player, Potion potion)
    {
        int maxHealth = GetMaxHealth(player.Type);
        
        // Vérifier si la vie est déjà au maximum
        if (player.Health >= maxHealth)
        {
            Console.WriteLine("💚 Votre vie est déjà au maximum !");
            return false;
        }
        else
        {
            // Appliquer les soins
            int healthBefore = player.Health;
            player.Health = Math.Min(player.Health + potion.HealAmount, maxHealth);
            int actualHeal = player.Health - healthBefore;

            Console.WriteLine($"💚 {potion.Name} utilisée ! +{actualHeal} PV (Vie: {player.Health}/{maxHealth})");
            return true;
        }

            
    }

    public static int GetMaxHealth(PlayerType type)
    {
        return type switch
        {
            PlayerType.Tank => 200,
            PlayerType.Chevalier => 120,
            PlayerType.Mage => 75,
            _ => 100
        };
    }

    public static void DisplayHealthBar(Player player)
    {
        int maxHealth = GetMaxHealth(player.Type);
        double healthPercent = (double)player.Health / maxHealth;
        int barLength = 20;
        int filledBars = (int)(healthPercent * barLength);

        string bar = "[" + new string('█', filledBars) + new string('░', barLength - filledBars) + "]";
        
        ConsoleColor color;
        if (healthPercent > 0.6)
            color = ConsoleColor.Green;
        else if (healthPercent > 0.3)
            color = ConsoleColor.Yellow;
        else
            color = ConsoleColor.Red;

        Console.ForegroundColor = color;
        Console.Write($"{bar} {player.Health}/{maxHealth} PV");
        Console.ResetColor();
        Console.WriteLine();
    }
}

