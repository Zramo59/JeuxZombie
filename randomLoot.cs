namespace JeuxZombie
{
    public enum LootType
    {
        Potion,
        Weapon,
        Gold
    }

    public class RandomLoot
    {
        private static Random _rng = new Random();

        public static void DropLoot(Player player, Zombie zombie)
        {
            // 70% de chance de drop, 30% rien
            if (_rng.Next(0, 100) < 30)
            {
                UIHelper.DisplayMessage("Aucun butin trouvé...", "🚫");
                return;
            }

            LootType lootType = (LootType)_rng.Next(0, Enum.GetValues(typeof(LootType)).Length);

            switch (lootType)
            {
                case LootType.Potion:
                    DropPotion(player);
                    break;
                case LootType.Weapon:
                    DropWeapon(player);
                    break;
                case LootType.Gold:
                    DropGold(player);
                    break;
            }
        }

        private static void DropPotion(Player player)
        {
            PotionType potionType = (PotionType)_rng.Next(0, Enum.GetValues(typeof(PotionType)).Length);
            Potion potion = new Potion();
            potion.InitialisePotion(potionType);

            if (player.Inventory.AddPotion(potion))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n  🧪 Vous avez trouvé une {potion.Name} (+{potion.HealAmount} PV) !");
                Console.ResetColor();
            }
            else
            {
                UIHelper.DisplayWarning("Votre inventaire est plein ! Potion perdue.");
            }
        }

        private static void DropWeapon(Player player)
        {
            string[] weaponNames = { "Épée Rouillée", "Dague Acérée", "Massue Lourde", "Arc Ancien", "Bâton Pétrifié" };
            int[] damages = { 25, 35, 23, 26, 25 };
            
            int index = _rng.Next(0, weaponNames.Length);
            string weaponName = weaponNames[index];
            int damage = damages[index] + _rng.Next(0, 10); // Variation aléatoire

            Weapon droppedWeapon = new Weapon(weaponName, damage, 0);

            // Remplacer l'arme actuelle ou garder la meilleure
            if (damage > player.CurrentWeapon.Damage)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n  ⚔️  Vous avez trouvé une arme : {weaponName} ({damage} dégâts) !");
                Console.ResetColor();
                player.CurrentWeapon = droppedWeapon;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"\n  ⚔️  Vous avez trouvé une arme : {weaponName} ({damage} dégâts), mais votre arme actuelle est meilleure.");
                Console.ResetColor();
            }
        }

        private static void DropGold(Player player)
        {
            int goldAmount = _rng.Next(10, 50);
            player.Gold += goldAmount;
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n  💰 Vous avez trouvé {goldAmount} pièces d'or !");
            Console.WriteLine($"     Total: {player.Gold} pièces d'or");
            Console.ResetColor();
        }
    }
}