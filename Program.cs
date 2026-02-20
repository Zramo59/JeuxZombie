namespace JeuxZombie
{
    class Program
    {
        private static void Main()
        {
            UIHelper.DisplayBanner("ZOMBIE APOCALYPSE");
            
            Player hero;
            
            // Vérifier s'il existe une sauvegarde
            if (SaveManager.HasSaveFile())
            {
                UIHelper.DisplayTitle("SAUVEGARDE DÉTECTÉE");
                string[] loadOptions = { "Charger la partie sauvegardée", "Nouvelle partie" };
                UIHelper.DisplayMenu("Menu Principal", loadOptions);
                
                int choice = Console.ReadKey(true).KeyChar - '1';
                
                if (choice == 0)
                {
                    Player? loadedPlayer = SaveManager.LoadGame();
                    if (loadedPlayer != null)
                    {
                        hero = loadedPlayer;
                        UIHelper.DisplaySuccess("Partie chargée avec succès !");
                        UIHelper.DisplayMessage($"Bienvenue de retour, {hero.Name} !", "👋");
                        UIHelper.PressAnyKey();
                    }
                    else
                    {
                        UIHelper.DisplayError("Erreur lors du chargement. Création d'une nouvelle partie...");
                        hero = CreateNewPlayer();
                    }
                }
                else
                {
                    DisplayIntroduction();
                    hero = CreateNewPlayer();
                }
            }
            else
            {
                DisplayIntroduction();
                hero = CreateNewPlayer();
            }

            UIHelper.DisplayTitle("BIENVENUE, " + hero.Name.ToUpper());
            UIHelper.DisplayPlayerStats(hero);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n  {hero.Description}");
            Console.ResetColor();
            UIHelper.PressAnyKey();

            bool boucle = true;
            CombatEngine engine = new CombatEngine();
            while (boucle)
            {
                Console.Clear();
                UIHelper.DisplayTitle("MENU PRINCIPAL");
                
                // Afficher le gold du joueur
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  [*] Or disponible : {hero.Gold} pieces\n");
                Console.ResetColor();
                
                string[] menuOptions = { "[1] Commencer un combat", "[2] Inventaire", "[3] Armes", "[4] Sauvegarder", "[5] Quitter le jeu" };
                UIHelper.DisplayMenu("Options Disponibles", menuOptions);

                ConsoleKeyInfo startKey = Console.ReadKey(true);

                switch (startKey.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        UIHelper.DisplayMessage("Engagement dans le combat...", "[>]");
                        Thread.Sleep(500);
                        Zombie enemy = new Zombie();
                        UIHelper.DisplayEnemyInfo(enemy);
                        engine.StartFight(hero, enemy);
                        UIHelper.PressAnyKey();
                        break;
                    case '2':
                        hero.Inventory.DisplayInventory(hero);
                        break;
                    case '3':
                        hero.DisplayWeaponsMenu();
                        break;
                    case '4':
                        Console.Clear();
                        UIHelper.DisplayMessage("Sauvegarde en cours...", "[S]");
                        SaveManager.SaveGame(hero);
                        UIHelper.DisplaySuccess("Partie sauvegardee avec succes !");
                        UIHelper.PressAnyKey();
                        break;
                    case '5':
                        Console.Clear();
                        UIHelper.DisplayBanner("A BIENTOT, HEROS !");
                        boucle = false;
                        break;
                }
            }
        }

        private static void DisplayIntroduction()
        {
            Console.Clear();
            UIHelper.DisplayBanner("L'HISTOIRE COMMENCE...");
            string intro = "On est au V siècle après Jésus Christ dans une contrée, un temps donné pour " +
                          "l'avancement de la science et d'invention en tout genre. Mais cette science rattrapa " +
                          "vite l'époque lors d'une découverte surprenante d'un objet quelque peu étrange... " +
                          "Les scientifiques de l'époque firent différents tests sur cet objet et n'y trouvèrent rien, " +
                          "mais après deux ans d'expérimentation, un gaz étrange sortit de l'orbe et se propagea dans ce village, " +
                          "changeant certains villageois en monstres assoiffés de chair humaine. Suite à cela, beaucoup de " +
                          "personnes tentèrent de survivre mais sans résultat... Alors cette \"Maladie\" se propagea et fit " +
                          "énormément de morts, mais un personnage du nom de...";
            
            UIHelper.DisplayTypingEffect(intro, 20);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n  Penses-tu réussir à survivre dans ce monde sombre et terrifiant ?");
            Console.ResetColor();
            UIHelper.PressAnyKey();
        }

        private static Player CreateNewPlayer()
        {
            UIHelper.DisplayTitle("CREATION DU PERSONNAGE");
            UIHelper.DisplayMessage("Choisissez un nom pour votre heros", "[+]");
            UIHelper.DisplayPrompt("Nom du personnage:");
            string playerName = Console.ReadLine() ?? "Heros";
            
            Console.Clear();
            UIHelper.DisplayTitle("SELECTION DE LA CLASSE");
            UIHelper.DisplayMessage($"Excellent choix, {playerName}!", "[*]");
            
            string[] classes = { 
                "[1] TANK (200 HP, Hache de guerre) - Defenseur robuste",
                "[2] KNIGHT (120 HP, Epee longue) - Combattant equilibre",
                "[3] MAGE (75 HP, Baton magique) - Utilisateur de magie"
            };
            
            Console.WriteLine();
            for (int i = 0; i < classes.Length; i++)
            {
                UIHelper.DisplayMenuItem(i + 1, classes[i].Split('-')[0].Trim());
            }
            
            UIHelper.DisplayPrompt("Choisissez votre classe:");
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
                    UIHelper.DisplayWarning("Choix invalide, classe Knight sélectionnée par défaut...");
                    hero = new Player(playerName, PlayerType.Knight);
                    Thread.Sleep(1000);
                    break;
            }
            
            return hero;
        }
    }
}
