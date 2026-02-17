using System;
namespace JeuxZombie
{
    public enum ZombieType
    {
        Normal,
        Berserk,
        Radioactif,
        Cuirassé
    }

    public class Zombie
    {
        private static Random _rng = new Random();

        public string Name { get; set; }
        public ZombieType Type { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int XpGiven { get; set; } 

        public Zombie()
        {
            // Génère un type de zombie aléatoire
            Type = (ZombieType)_rng.Next(0, Enum.GetValues(typeof(ZombieType)).Length + 1);
            InitializeStats(Type);
        }

        public Zombie(ZombieType type)
        {
            Type = type;
            InitializeStats(type);
        }

        private void InitializeStats(ZombieType type)
        {
            
            switch (type)
            {
                case ZombieType.Berserk:
                    Name = "Zombie Berserk";
                    Health = 80;
                    Damage = 25;
                    XpGiven = _rng.Next(15, 25); // XP aléatoire entre 15 et 25
                    break;
                case ZombieType.Radioactif:
                    Name = "Zombie Radioactif";
                    Health = 120;
                    Damage = 10;
                    XpGiven = _rng.Next(20, 30); // XP aléatoire entre 10 et 20
                    break;
                case ZombieType.Cuirassé:
                    Name = "Zombie Cuirassé";
                    Health = 200;
                    Damage = 15;
                    XpGiven = _rng.Next(25, 30); //  XP aléatoire entre 25 et 30
                    break;
                default:
                    Name = "Zombie Commun";
                    Health = 100;
                    Damage = 12;
                    XpGiven = _rng.Next(5, 15); // XP aléatoire entre 5 et 15
                    break;
            }
        }
    }
}