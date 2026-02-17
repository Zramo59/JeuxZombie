namespace JeuxZombie
{
    public enum PlayerType { Tank, Knight, Mage }

    public class Player
    {
        public string Name { get; set; }
        public PlayerType Type { get; set; }
        public int Health { get; set; }
        public Weapon CurrentWeapon { get; set; } = new Weapon("Default Weapon", 0, 0);
        public string Description { get; set; } = string.Empty;
        public Inventory Inventory { get; set; }

        public Player(string name, PlayerType type)
        {
            Name = name;
            InitialisePlayer(type);
            Inventory = new Inventory(5); // Initialize inventory before adding potions

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

        private Potion InitialisePotion(PotionType type)
        {
            var potion = new Potion();
            potion.InitialisePotion(type);
            return potion;
        }
    }
}
