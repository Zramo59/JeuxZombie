namespace JeuxZombie
{
    public class Dodge
    {
        private Random _rng = new Random();
        
        // Dodge du joueur (basé sur sa classe)
        public bool TryPlayerDodge(Player player)
        {
            int dodgeChance = GetPlayerDodgeChance(player.Type);
            
            if (_rng.Next(0, 100) < dodgeChance)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n  🧑 Vous avez esquivé l'attaque !");
                Console.ResetColor();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        // Dodge de l'ennemi (basé sur son type)
        public bool TryEnemyDodge(Zombie zombie)
        {
            int dodgeChance = GetEnemyDodgeChance(zombie.Type);
            
            if (_rng.Next(0, 100) < dodgeChance)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n  🧟 Le {zombie.Name} a esquivé votre attaque !");
                Console.ResetColor();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        // Chance de dodge selon la classe du joueur
        private int GetPlayerDodgeChance(PlayerType type)
        {
            return type switch
            {
                PlayerType.Tank => 10,      // Lourd et lent
                PlayerType.Knight => 25,    // Équilibré
                PlayerType.Mage => 35,      // Léger et agile
                _ => 20
            };
        }
        
        // Chance de dodge selon le type de zombie
        private int GetEnemyDodgeChance(ZombieType type)
        {
            return type switch
            {
                ZombieType.Normal => 20,        // Moyen
                ZombieType.Berserk => 15,      // Agressif, moins agile
                ZombieType.Radioactif => 25,   // Prudent et agile
                ZombieType.Cuirassé => 10,     // Lourd et lent
                _ => 15
            };
        }
    }
}