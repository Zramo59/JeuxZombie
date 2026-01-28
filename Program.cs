class Program
{
    static void Main()
    {
        // Saisie du nom
        Console.WriteLine("Entrez votre nom :");
        string playerName = Console.ReadLine();

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

        // Menu de sélection du type de zombie
        Console.WriteLine("\n=== CHOISIR LE TYPE DE ZOMBIE ===");
        Console.WriteLine("1 - Zombie Normal (100 PV, 12 dégâts)");
        Console.WriteLine("2 - Zombie Berserk (80 PV, 25 dégâts)");
        Console.WriteLine("3 - Zombie Radioactif (120 PV, 10 dégâts)");
        Console.WriteLine("4 - Zombie Cuirassé (200 PV, 15 dégâts)");
        Console.WriteLine("Appuyez sur une touche (1-4):");

        ConsoleKeyInfo zombieKey = Console.ReadKey(true);
        Zombie enemy;

        switch (zombieKey.KeyChar)
        {
            case '1':
                enemy = new Zombie(ZombieType.Normal);
                break;
            case '2':
                enemy = new Zombie(ZombieType.Berserk);
                break;
            case '3':
                enemy = new Zombie(ZombieType.Radioactif);
                break;
            case '4':
                enemy = new Zombie(ZombieType.Cuirassé);
                break;
            default:
                Console.WriteLine("Touche invalide, génération aléatoire...");
                enemy = new Zombie();
                break;
        }

        Console.WriteLine($"\n✓ Ennemi : {enemy.Name}\n");

        CombatEngine engine = new CombatEngine();

        // Lancement
        engine.StartFight(hero, enemy);
    }
}