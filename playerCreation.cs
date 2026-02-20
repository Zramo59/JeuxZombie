namespace JeuxZombie
{
    public enum PlayerType { Tank, Knight, Mage }

    public class Player
    {
        public string Name { get; set; }
        public PlayerType Type { get; set; }
        public int Health { get; set; }
        public int MaxHealthBonus { get; set; } = 0; // Bonus de PV max à chaque level up
        public int Gold { get; set; } = 0;
        public Weapon CurrentWeapon { get; set; } = new Weapon("Default Weapon", 0, 0);
        public string Description { get; set; } = string.Empty;
        public Inventory Inventory { get; set; }
        public Xp Xp { get; set; } = new Xp();

        public Player(string name, PlayerType type)
        {
            Name = name;
            InitialisePlayer(type);
            Inventory = new Inventory(5); // Initialize inventory before adding potions
            Xp.Player = this; // Ajouter la référence du joueur au système d'XP

            // Ajouter quelques potions de départ
            Inventory.AddPotion(InitialisePotion(PotionType.Small));
            Inventory.AddPotion(InitialisePotion(PotionType.Medium));
            Inventory.AddPotion(InitialisePotion(PotionType.Large));
        }

        private void InitialisePlayer(PlayerType type)
        {
            Type = type;
            switch (type)
            {
                case PlayerType.Tank:
                    Health = 200;
                    CurrentWeapon = new Weapon("Hache de guerre", 15, 0);
                    Description = "Un guerrier robuste, spécialisé dans la défense et le combat rapproché.";
                    break;
                case PlayerType.Knight:
                    Health = 120;
                    CurrentWeapon = new Weapon("Épée longue", 25, 0);
                    Description = "Un combattant équilibré, alliant force et agilité avec une épée polyvalente.";
                    break;
                case PlayerType.Mage:
                    Health = 75;
                    CurrentWeapon = new Weapon("Bâton magique", 10, 50);
                    Description = "Un utilisateur de magie puissant, capable d'infliger des dégâts à distance avec des sorts.";
                    break;
            }
        }

        public int GetMaxHealth()
        {
            int baseMaxHealth = HealthManager.GetMaxHealthPlayer(Type);
            return baseMaxHealth + MaxHealthBonus;
        }

        public void DisplayWeaponsMenu()
        {
            bool inWeaponsMenu = true;
            while (inWeaponsMenu)
            {
                Console.Clear();
                UIHelper.DisplayTitle("⚔️  INFORMATIONS DES ARMES");
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  ═══════════════════════════════════════\n");
                Console.ResetColor();

                // Afficher l'arme actuelle
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  [*] ARME ÉQUIPÉE:\n");
                Console.ResetColor();
                CurrentWeapon.DisplayWeaponInfo();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  ═══════════════════════════════════════\n");
                Console.ResetColor();

                // Menu d'action
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  [1] Réparer l'arme");
                Console.WriteLine("  [2] Retour au menu");
                Console.ResetColor();

                Console.WriteLine();
                UIHelper.DisplayPrompt("Choisissez une action");
                ConsoleKeyInfo choice = Console.ReadKey(true);

                switch (choice.KeyChar)
                {
                    case '1':
                        // Utiliser la nouvelle méthode TryRepair() qui gère le coût aléatoire
                        CurrentWeapon.TryRepair(this);
                        UIHelper.PressAnyKey();
                        break;

                    case '2':
                        inWeaponsMenu = false;
                        break;

                    default:
                        UIHelper.DisplayError("Choix invalide !");
                        UIHelper.PressAnyKey();
                        break;
                }
            }
        }

        private Potion InitialisePotion(PotionType type)
        {
            var potion = new Potion();
            potion.InitialisePotion(type);
            return potion;
        }
    }
}
