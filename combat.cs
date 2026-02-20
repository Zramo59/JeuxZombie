namespace JeuxZombie
{
    public class CombatEngine
    {
        private static Random _rng = new Random();

        public void StartFight(Player player, Zombie zomb)
        {
            Console.Clear();
            DisplayCombatIntro(player, zomb);

            // Déterminer qui commence (Initiative)
            bool playerTurn = _rng.Next(0, 2) == 0;
            if (playerTurn)
                UIHelper.DisplaySuccess("Vous avez l'initiative !");
            else
                UIHelper.DisplayWarning($"Le {zomb.Name} vous surprend !");
            
            UIHelper.PressAnyKey();

            while (player.Health > 0 && zomb.Health > 0)
            {
                if (playerTurn)
                {
                    // Tour du Joueur - Choix d'action
                    Console.Clear();
                    DisplayCombatStatus(player, zomb);
                    
                    Console.WriteLine();
                    string[] actions = { "[1] Attaquer", "[2] Utiliser une potion", "[3] Voir l'inventaire", "[4] Fuir le combat" };
                    UIHelper.DisplayMenu("VOTRE TOUR", actions);

                    ConsoleKeyInfo actionKey = Console.ReadKey(true);
                    Console.WriteLine();

                    switch (actionKey.KeyChar)
                    {
                        case '1':
                            HandlePlayerAttack(player, zomb);
                            break;

                        case '2':
                            // Utiliser une potion
                            bool potionUsed = HealthManager.UsePotion(player);
                            if (!potionUsed)
                            {
                                UIHelper.DisplayWarning("Vous ne consommez pas votre tour.");
                                playerTurn = true; // Le joueur rejoue
                                continue;
                            }
                            break;

                        case '3':
                            // Afficher l'inventaire
                            player.Inventory.DisplayInventory(player);
                            UIHelper.DisplayWarning("Vous ne consommez pas votre tour.");
                            playerTurn = true; // Le joueur rejoue
                            continue;

                        case '4':
                            RunAway attempt = new RunAway();
                            bool escaped = attempt.TryToFlee(player, zomb);
                            if (escaped)
                            {
                                UIHelper.DisplaySuccess("Vous avez reussi a fuir le combat !");
                                return; // Fin du combat
                            }
                            else
                            {
                                UIHelper.DisplayError("La fuite a echoue ! Le combat continue.");
                            }

                            break;

                        default:
                            UIHelper.DisplayError("Action invalide, vous perdez votre tour !");
                            break;
                    }
                }
                else
                {
                    // Tour du Zombie
                    Console.Clear();
                    DisplayCombatStatus(player, zomb);
                    
                    // Vérifier si le joueur esquive avec sa propre chance
                    Dodge dodge = new Dodge();
                    if (dodge.TryPlayerDodge(player))
                    {
                        UIHelper.PressAnyKey();
                    }
                    else
                    {
                        int dmgTaken = zomb.Damage;
                        player.Health -= dmgTaken;
                        
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n  >> Le {zomb.Name} frappe ! Vous perdez {dmgTaken} PV.");
                        Console.ResetColor();
                        
                        // Effet spécial du zombie radioactif
                        zomb.ZombieRadioctifEffect(player);
                        
                        UIHelper.PressAnyKey();
                    }
                }

                playerTurn = !playerTurn;
            }

            // Résultat
            DisplayFightResult(player, zomb);
        }

        private void HandlePlayerAttack(Player player, Zombie zomb)
        {
            // Vérifier si le zombie esquive avec sa propre chance
            Dodge dodge = new Dodge();
            if (dodge.TryEnemyDodge(zomb))
            {
                return;
            }

            if (player.CurrentWeapon.Durability <= 0)
            {
                UIHelper.DisplayError("Votre arme est brisee !");
                int minDamage = 2;
                minDamage = zomb.ZombieCuirasseEffect(minDamage);
                zomb.Health -= minDamage;
                UIHelper.DisplayMessage($"Degats infliges: {minDamage}", "*");
            }
            // On ne vérifie les munitions QUE pour le Mage (ou si l'arme en a de base).
            else if (player.Type == PlayerType.Mage && player.CurrentWeapon.Ammo <= 0)
            {
                UIHelper.DisplayWarning("Plus de mana / munitions !");
                int weakDamage = 5;
                weakDamage = zomb.ZombieCuirasseEffect(weakDamage);
                zomb.Health -= weakDamage;
                UIHelper.DisplayMessage($"Degats faibles infliges: {weakDamage}", "*");
            }
            else
            {
                int baseRealDamage = player.CurrentWeapon.GetCurrentDamage();
                int dmgDealt = baseRealDamage;
                dmgDealt = zomb.ZombieCuirasseEffect(dmgDealt);
                zomb.Health -= dmgDealt;
                player.CurrentWeapon.Use();
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n  >> {player.CurrentWeapon.Model} inflige {dmgDealt} degats !");
                
                // Afficher l'état de la durabilité si elle est faible
                if (player.CurrentWeapon.Durability < 30)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"     ⚠️  Durabilité: {player.CurrentWeapon.Durability}%");
                }
                Console.ResetColor();
            }
            
            // Vérifier si le Berserk doit entrer en rage
            zomb.ZombieBerserkEffect();
        }
        
        
        private void DisplayCombatIntro(Player player, Zombie zomb)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + new string('═', 60));
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  === COMBAT ENGAGE ! ===");
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n  VOUS        : {player.Name.PadRight(40)}");
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  ADVERSAIRE : {zomb.Name.PadRight(40)}");
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string('═', 60) + "\n");
            Console.ResetColor();
        }

        private void DisplayCombatStatus(Player player, Zombie zomb)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  +════════════════════════════════════════════════════════+");
            Console.WriteLine($"  |  {player.Name.PadRight(20)} VS {zomb.Name.PadRight(26)} |");
            Console.WriteLine("  +════════════════════════════════════════════════════════+\n");
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ═══════════════════════════════════════");
            Console.WriteLine("  VOS STATS");
            Console.WriteLine("  ═══════════════════════════════════════");
            Console.ResetColor();
            HealthManager.DisplayHealthBarPlayer(player);
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  ═══════════════════════════════════════");
            Console.WriteLine("  STATS ENNEMI");
            Console.WriteLine("  ═══════════════════════════════════════");
            Console.ResetColor();
            HealthManager.DisplayHealthBarEnemy(zomb);
            Console.WriteLine();
        }

        private void DisplayFightResult(Player player, Zombie zomb)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n" + new string('═', 60));
            Console.ResetColor();
            
            if (player.Health > 0)
            {
                UIHelper.DisplaySuccess($"VICTOIRE ! Vous avez terrasse le {zomb.Name}.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"  > Vie restante : {player.Health} PV");
                Console.ResetColor();
                
                player.Xp.GainXp(zomb.XpGiven);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  > Vous gagnez {zomb.XpGiven} XP !");
                Console.ResetColor();
                
                // Drop du butin
                Console.WriteLine();
                RandomLoot.DropLoot(player, zomb);
            }
            else
            {
                UIHelper.DisplayError("GAME OVER... Vous avez ete devore.");
                UIHelper.DisplayMessage("Que faire ?", "?");
                
                string[] gameOverOptions = { "Recommencer", "Quitter" };
                UIHelper.DisplayMenu("Menu", gameOverOptions);
            
                ConsoleKeyInfo whatDoYouWant = Console.ReadKey(true);

                switch (whatDoYouWant.KeyChar)
                {
                    case '1':
                        UIHelper.DisplayMessage("Relancement du combat...", "~");
                        Thread.Sleep(1000);
                        player.Health = HealthManager.GetMaxHealthPlayer(player.Type);
                        StartFight(player, new Zombie());
                        break;
                    case '2':
                        UIHelper.DisplayMessage("Merci d'avoir joue !", "o");
                        break;
                    default:
                        UIHelper.DisplayWarning("Touche invalide, fermeture du jeu...");
                        break;
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('═', 60));
            Console.ResetColor();
        }
    }
}
