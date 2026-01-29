namespace JeuxZombie
{
    public class CombatEngine
    {
        private static Random _rng = new Random();

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
                    Console.WriteLine("4 - Fuir le combat");
                    Console.Write("Choisissez une action : ");

                    ConsoleKeyInfo actionKey = Console.ReadKey(true);
                    Console.WriteLine();

                    switch (actionKey.KeyChar)
                    {
                        case '1':
                            if (player.CurrentWeapon.Durability <= 0)
                            {
                                Console.WriteLine("❌ Votre arme est brisée !");
                                zomb.Health -= 2;
                            }
                            // On ne vérifie les munitions QUE pour le Mage (ou si l'arme en a de base)
                            else if (player.Type == PlayerType.Mage && player.CurrentWeapon.Ammo <= 0)
                            {
                                Console.WriteLine("⚠️ Plus de mana / munitions !");
                                zomb.Health -= 5;
                            }
                            else
                            {
                                int dmgDealt = player.CurrentWeapon.Damage;
                                zomb.Health -= dmgDealt;
                                player.CurrentWeapon.Use();
                                Console.WriteLine($"[JOUEUR] Vous infligez {dmgDealt} dégâts.");
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

                        case '4':
                            RunAway attempt = new RunAway();
                            bool escaped = attempt.TryToFlee(player, zomb);
                            if (escaped)
                            {
                                Console.WriteLine("🏃 Vous avez réussi à fuir le combat !");
                                return; // Fin du combat
                            }
                            else
                            {
                                Console.WriteLine("❌ La fuite a échoué ! Le combat continue.");
                            }

                            break;

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
                Thread.Sleep(800);
            }

            // Résultat
            Console.WriteLine("\n" + new string('=', 50));
            if (player.Health > 0)
            {
                Console.WriteLine($"✅ VICTOIRE ! Vous avez terrassé le {zomb.Name}.");
                Console.WriteLine($"💚 Vie restante : {player.Health.ToString()} PV");

                // Récompense : potion aléatoire
                // //fix reward (peut être faire une liste d'objets pour plusieurs types de récompenses)
                // if (!player.Inventory.IsFull)
                // {
                //     PotionType rewardType = (PotionType)_rng.Next(0, 3);
                //     player.Inventory.AddToInventory(rewardType);
                //     Console.WriteLine("🎁 Vous avez trouvé une potion sur le zombie !");
                // }
            }
            else
            {
                Console.WriteLine("💀 Game Over... Vous avez été dévoré.");
                ConsoleKeyInfo whatDoYouWant = Console.ReadKey(true);
                Console.WriteLine("=====Que faire ?=====");
                Console.WriteLine("1 - Recommencer");
                Console.WriteLine("2 - Quitter");
            
                switch (whatDoYouWant.KeyChar)
                {
                    // case '1':
                    //     StartFight(Player player, Zombie zomb);
                    //     break;
                    case '2':
                        Console.WriteLine("Merci d'avoir joué !");
                        break;
                    default:
                        Console.WriteLine("Touche invalide, fermeture du jeu...");
                        break;
                }
            }
        }
    }
}
