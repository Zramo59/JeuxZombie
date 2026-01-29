namespace JeuxZombie
{
    class Program
    {
        static void Main()
        {
            // Saisie du nom
            Console.WriteLine("Entrez votre nom :");
            string playerName = Console.ReadLine() ?? "Joueur";

            // Menu de sélection du type de joueur
            Console.WriteLine("\n=== CHOISIR VOTRE CLASSE ===");
            Console.WriteLine("1 - Tank (200 PV, Hache de guerre)");
            Console.WriteLine("2 - Chevalier (120 PV, Épée longue)");
            Console.WriteLine("3 - Mage (75 PV, Bâton magique)");
            Console.WriteLine("Appuyez sur une touche (1-3):");

            ConsoleKeyInfo playerKey = Console.ReadKey(true);
            Player hero;
            

            switch (playerKey.KeyChar)
            {
                case '1':
                    hero = new Player(playerName, PlayerType.Tank);
                    break;
                case '2':
                    hero = new Player(playerName, PlayerType.Chevalier);
                    break;
                case '3':
                    hero = new Player(playerName, PlayerType.Mage);
                    break;
                default:
                    Console.WriteLine("Touche invalide, classe Chevalier par défaut...");
                    hero = new Player(playerName, PlayerType.Chevalier);
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
                        hero.Inventory.DisplayInventory();
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
