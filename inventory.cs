namespace JeuxZombie
{
    public enum PotionType
    {
        Small,
        Medium,
        Large
    }

    public class Potion
    {
        public PotionType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public int HealAmount { get; set; }

        public void InitialisePotion(PotionType type)
        {
            switch (type)
            {
                case PotionType.Small:
                    Name = "Potion Petite";
                    HealAmount = 20;
                    break;
                case PotionType.Medium:
                    Name = "Potion Moyenne";
                    HealAmount = 50;
                    break;
                case PotionType.Large:
                    Name = "Potion Grande";
                    HealAmount = 100;
                    break;
            }
        }
    }

    public class Inventory
    {
        private List<Potion> _potions;
        private int _maxCapacity;

        public Inventory(int maxCapacity)
        {
            _potions = new List<Potion>();
            _maxCapacity = maxCapacity;
        }

        public bool AddPotion(Potion potion)
        {
            if (_potions.Count >= _maxCapacity)
            {
                Console.WriteLine("Inventaire plein !");
                return false;
            }

            _potions.Add(potion);
            return true;
        }

        public void DisplayInventory(Player player)
        {
            Console.WriteLine($"\n=== INVENTAIRE ({_potions.Count}/{_maxCapacity}) ===");

            var grouped = _potions.GroupBy(p => p.Type).OrderBy(g => g.Key);

            int index = 1;
            foreach (var group in grouped)
            {
                Console.WriteLine($"  {index}. {group.First().Name} (+{group.First().HealAmount} PV) x{group.Count()}");
                index++;
            }

            HealthManager.DisplayHealthBar(player);
            player.Xp.DisplayXp();
            // ConsoleKeyInfo actionKey = Console.ReadKey(true);
            // switch (actionKey.KeyChar)           {
            //     case "1":
            //         HealthManager.UsePotion(player);
            //         continue;
            //     case '2':
            //         Console.WriteLine("Retour au menu...");
            //         break;
            // }
        }
        
        public bool RemovePotion(Potion potion)
        {
            return _potions.Remove(potion);
        }
        
        public bool AddToInventory(Potion potion)
        {
            if (_potions.Count >= _maxCapacity)
            {
                return false;
            }

            _potions.Add(potion);
            return true;
        }
        
        public bool IsFull => _potions.Count >= _maxCapacity;

        public bool IsEmpty => !_potions.Any();

        public Potion? GetPotion(PotionType type)
        {
            return _potions.FirstOrDefault(p => p.Type == type);
        }

        public Potion? GetAnyPotion()
        {
            return _potions.FirstOrDefault();
        }
    }
}
