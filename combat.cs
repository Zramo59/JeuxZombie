using System;

public class CombatEngine
{
    private static Random _rng = new Random();
    private int encounter = _rng.Next(0, 3);
    
    public void StartFight(Player player, Zombie zomb)
    {
        Console.WriteLine($"--- DÉBUT DU COMBAT : {player.Name} VS {zomb.Name} ---");
        
        // Afficher l'inventaire de départ
        player.Inventory.DisplayInventory();

        // Déterminer qui commence (Initiative)
        bool playerTurn = _rng.Next(0, 2) == 0;
        Console.WriteLine(playerTurn ? "> Vous avez l'initiative !" : $"> Le {zomb.Name} vous surprend !");

        while (player.Health > 0 && zomb.Health > 0)
        {
            if (playerTurn)
            {
                // Tour du Joueur - Choix d'action
                Console.WriteLine("\n--- VOTRE TOUR ---");
                HealthManager.DisplayHealthBar(player);
                Console.WriteLine("1 - Attaquer");
                Console.WriteLine("2 - Utiliser une potion");
                Console.WriteLine("3 - Voir l'inventaire");
                Console.Write("Choisissez une action : ");

                ConsoleKeyInfo actionKey = Console.ReadKey(true);
                Console.WriteLine();

                switch (actionKey.KeyChar)
                {
                    case '1':
                        // Attaque
                        if (player.CurrentWeapon.Durability <= 0)
                        {
                            Console.WriteLine("❌ Votre arme est brisée ! Vous attaquez faiblement à mains nues.");
                            zomb.Health -= 2;
                        }
                        else if (player.CurrentWeapon.Ammo <= 0)
                        {
                            Console.WriteLine("⚠️ Plus de munitions !");
                            zomb.Health -= 5;
                        }
                        else
                        {
                            int dmgDealt = player.CurrentWeapon.Damage;
                            zomb.Health -= dmgDealt;
                            player.CurrentWeapon.Use();
                            Console.WriteLine($"[JOUEUR] Vous infligez {dmgDealt} dégâts. (Vie Zombie: {Math.Max(0, zomb.Health)})");
                        }
                        break;

                    case '2':
                        // Utiliser une potion
                        bool potionUsed = HealthManager.UsePotion(player);
                        if (!potionUsed)
                        {
                            Console.WriteLine("⚠️ Vous ne consommez pas votre tour.");
                            playerTurn = true; // Le joueur rejoue
                            continue;
                        }
                        break;

                    case '3':
                        // Afficher l'inventaire
                        player.Inventory.DisplayInventory();
                        Console.WriteLine("⚠️ Vous ne consommez pas votre tour.");
                        playerTurn = true; // Le joueur rejoue
                        continue;

                    default:
                        Console.WriteLine("❌ Action invalide, vous perdez votre tour !");
                        break;
                }
            }
            else
            {
                // Tour du Zombie
                int dmgTaken = zomb.Damage;
                player.Health -= dmgTaken;
                Console.WriteLine($"\n[ZOMBIE] Le {zomb.Name} frappe ! Vous perdez {dmgTaken} PV.");
                HealthManager.DisplayHealthBar(player);
            }

            playerTurn = !playerTurn;
            System.Threading.Thread.Sleep(800);
        }

        // Résultat
        Console.WriteLine("\n" + new string('=', 50));
        if (player.Health > 0)
        {
            Console.WriteLine($"✅ VICTOIRE ! Vous avez terrassé le {zomb.Name}.");
            Console.WriteLine($"💚 Vie restante : {player.Health} PV");
            
            // Récompense : potion aléatoire
            if (!player.Inventory.IsFull)
            {
                PotionType rewardType = (PotionType)_rng.Next(0, 3);
                player.Inventory.AddPotion(new Potion(rewardType));
                Console.WriteLine("🎁 Vous avez trouvé une potion sur le zombie !");
            }
        }
        else
        {
            Console.WriteLine("💀 Game Over... Vous avez été dévoré.");
        }
    }
}