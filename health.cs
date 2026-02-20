﻿namespace JeuxZombie
{
    public class HealthManager
    {
        public int HealthBonus = 0; // Correction du nom pour respecter les conventions
        public static bool UsePotion(Player player, PotionType? potionType = null)
        {
            if (player.Inventory.IsEmpty)
            {
                UIHelper.DisplayError("Aucune potion disponible dans l'inventaire !");
                return false;
            }

            // Récupérer la potion à refaire incoherence au niveaux de la création fonction
            Potion? potion;
            if (potionType.HasValue)
            {
                potion = player.Inventory.GetPotion(potionType.Value);
                if (potion == null)
                {
                    UIHelper.DisplayError($"Aucune potion de type {potionType.Value} disponible !");
                    return false;
                }
            }
            else
            {
                // utilisation des potions dans l'ordre (sois petite -> moyenne -> grande)
                potion = player.Inventory.GetAnyPotion();
                if (potion == null)
                {
                    UIHelper.DisplayError("Aucune potion trouvée !");
                    return false;
                }
                player.Inventory.RemovePotion(potion); // en création d'une fonction pour retirer une potion spécifique
            }

            return ApplyPotion(player, potion);
        }

        private static bool ApplyPotion(Player player, Potion potion)
        {
            int maxHealth = player.GetMaxHealth();
            
            // Vérifier si la vie est déjà au maximum
            if (player.Health >= maxHealth)
            {
                UIHelper.DisplayWarning("Votre vie est déjà au maximum !");
                return false;
            }
            else
            {
                // Appliquer les soins
                int healthBefore = player.Health;
                player.Health = Math.Min(player.Health + potion.HealAmount, maxHealth);
                int actualHeal = player.Health - healthBefore;

                UIHelper.DisplaySuccess($"{potion.Name} utilisée ! +{actualHeal} PV (Vie: {player.Health}/{maxHealth})");
                return true;
            }
        }

        public static int GetMaxHealthPlayer(PlayerType type)
        {
            return type switch
            {
                PlayerType.Tank => 200,
                PlayerType.Knight => 120,
                PlayerType.Mage => 75,
                _ => 100
            };
        }
        
        public static int GetMaxHealthEnemy(ZombieType type)
        {
            return type switch
            {
                ZombieType.Radioactif => 120,
                ZombieType.Berserk => 80,
                ZombieType.Cuirassé => 200,
                ZombieType.Normal => 100,
                _ => 50
            };
        }

        public static void DisplayHealthBarPlayer(Player player)
        {
            int maxHealth = player.GetMaxHealth();
            int currentHealth = Math.Max(0, player.Health); // Assurer que la santé n'est pas négative
            ConsoleColor barColor = GetHealthColor((int)((double)currentHealth / maxHealth * 100));
            UIHelper.DisplayColoredBar("Vie", currentHealth, maxHealth, barColor);
        }

        public static void DisplayHealthBarEnemy(Zombie zombie)
        {
            int maxHealth = GetMaxHealthEnemy(zombie.Type);
            int currentHealth = Math.Max(0, zombie.Health); // Assurer que la santé n'est pas négative
            ConsoleColor barColor = GetHealthColor((int)((double)currentHealth / maxHealth * 100));
            UIHelper.DisplayColoredBar("Ennemi", currentHealth, maxHealth, barColor);
        }

        private static ConsoleColor GetHealthColor(int percentage)
        {
            if (percentage > 50)
                return ConsoleColor.Green;
            else if (percentage > 25)
                return ConsoleColor.Yellow;
            else
                return ConsoleColor.Red;
        }
    }
}
