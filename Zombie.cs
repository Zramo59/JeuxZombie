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
        
        public void ZombieRadioctifEffect(Player player)
        {
            if (Type == ZombieType.Radioactif)
            {
                int radiationDamage = 5; // Dégâts de radiation par tour
                player.Health -= radiationDamage;
                Console.WriteLine($"☢️ Le {Name} inflige {radiationDamage} dégâts de radiation à {player.Name} !");
            }
        }

        public void ZombieBerserkEffect()
        {
            if (Type == ZombieType.Berserk && Health < 40)
            {
                // Le Berserk devient enragé quand sa vie est basse
                int bonusDamage = 10;
                Damage += bonusDamage;
                Console.WriteLine($"💢 Le {Name} entre en rage ! Ses dégâts augmentent de {bonusDamage} !");
            }
        }

        public int ZombieCuirasseEffect(int incomingDamage)
        {
            if (Type == ZombieType.Cuirassé)
            {
                // Le Cuirassé réduit les dégâts reçus
                int damageReduction = (int)(incomingDamage * 0.2); // Réduit de 20%
                int finalDamage = incomingDamage - damageReduction;
                if (damageReduction > 0)
                {
                    Console.WriteLine($"🛡️ L'armure du {Name} absorbe {damageReduction} dégâts !");
                }
                return finalDamage;
            }
            return incomingDamage;
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