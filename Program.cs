namespace JeuxZombie
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("Welcome to my terminal game !");
            
            Player hero;
            
            // Vérifier s'il existe une sauvegarde
            if (SaveManager.HasSaveFile())
            {
                Console.WriteLine("\n=== SAUVEGARDE DÉTECTÉE ===");
                Console.WriteLine("1 - Charger la partie sauvegardée");
                Console.WriteLine("2 - Nouvelle partie");
                Console.WriteLine("Appuyez sur 1 ou 2 :");
                
                ConsoleKeyInfo loadChoice = Console.ReadKey(true);
                
                if (loadChoice.KeyChar == '1')
                {
                    Player? loadedPlayer = SaveManager.LoadGame();
                    if (loadedPlayer != null)
                    {
                        hero = loadedPlayer;
                        Console.WriteLine("\n✓ Partie chargée avec succès !");
                        Console.WriteLine($"Bienvenue de retour, {hero.Name} !");
                    }
                    else
                    {
                        Console.WriteLine("Erreur lors du chargement. Création d'une nouvelle partie...");
                        hero = CreateNewPlayer();
                    }
                }
                else
                {
                    Console.WriteLine("\nCréation d'une nouvelle partie...");
                    hero = CreateNewPlayer();
                }
            }
            else
            {
                hero = CreateNewPlayer();
            }

            Console.WriteLine($"\n✓ Classe : {hero.Type}");
            Console.WriteLine($"  {hero.Description}");

            bool boucle = true;
            CombatEngine engine = new CombatEngine();
            while (boucle)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1 - Start Fight");
                Console.WriteLine("2 - Inventory");
                Console.WriteLine("3 - Save Game");
                Console.WriteLine("4 - Left Game");
                Console.WriteLine("Push keychar (1-4):");

                ConsoleKeyInfo startKey = Console.ReadKey(true);

                switch (startKey.KeyChar)
                {
                    case '1':
                        Console.WriteLine("commencer le combat...");
                        Zombie enemy = new Zombie();
                        Console.WriteLine($"\n✓ Ennemi : {enemy.Name}\n");
                        engine.StartFight(hero, enemy);
                        break;
                    case '2':
                        Console.WriteLine("Accèder à l'inventaire...");
                        hero.Inventory.DisplayInventory(hero);
                        break;
                    case '3':
                        Console.WriteLine("Sauvegarder la partie...");
                        SaveManager.SaveGame(hero);
                        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                        Console.ReadKey(true);
                        break;
                    case '4':
                        Console.WriteLine("Quitter le jeu...");
                        boucle = false;
                        break;
                }
            }
        }

        private static Player CreateNewPlayer()
        {
            Console.WriteLine("At first, you have to choose your name character :");
            string playerName = Console.ReadLine() ?? "Player";
            Console.WriteLine($"Good {playerName}, you have many class in my world, you can choose between :");
            Console.WriteLine("1 - Tank (200 HP, War Axe)");
            Console.WriteLine("2 - Knight (120 HP, Long Sword)");
            Console.WriteLine("3 - Mage (75 HP, Magic Staff)");
            Console.WriteLine("Just press a key (1-3) to choose your class :");
            ConsoleKeyInfo playerKey = Console.ReadKey(true);
            
            Player hero;
            switch (playerKey.KeyChar)
            {
                case '1':
                    hero = new Player(playerName, PlayerType.Tank);
                    break;
                case '2':
                    hero = new Player(playerName, PlayerType.Knight);
                    break;
                case '3':
                    hero = new Player(playerName, PlayerType.Mage);
                    break;
                default:
                    Console.WriteLine("Invalid key, Knight class by default...");
                    hero = new Player(playerName, PlayerType.Knight);
                    break;
            }
            
            return hero;
        }
    }
}
