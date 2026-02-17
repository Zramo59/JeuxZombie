namespace JeuxZombie
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("Welcome to my terminal game !");
            Console.WriteLine("At first, you have to choose your character :");
            string playerName = Console.ReadLine() ?? "Player";
            Console.WriteLine($"Good {playerName}, you have many class in my world, you can choose between :");
            Console.WriteLine("1 - Tank (200 HP, War Axe)");
            Console.WriteLine("2 - Knight (120 HP, Long Sword)");
            Console.WriteLine("3 - Mage (75 HP, Magic Staff)");
            Console.WriteLine("Just press a key (1-3) to choose your class :");
            ConsoleKeyInfo playerKey = Console.ReadKey(true);
            Player hero;
            switch (playerKey.KeyChar)            {
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

            Console.WriteLine($"\n✓ Vous avez choisi : {hero.Type}");
            Console.WriteLine($"  {hero.Description}");

            bool boucle = true;
            CombatEngine engine = new CombatEngine();
            while (boucle)
            {
                Console.WriteLine("\n=== MENU PRINCIPAL ===");
                Console.WriteLine("1 - Commencer un combat");
                Console.WriteLine("2 - Voir l'inventaire");
                Console.WriteLine("3 - Quitter le jeu");
                Console.WriteLine("Appuyez sur une touche (1-3):");

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
                        Console.WriteLine("Quitter le jeu...");
                        boucle = false;
                        break;
                }
            }
        }
    }
}
