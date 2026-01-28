public enum ZombieType { Normal, Berserk, Radioactif, Cuirassé }

public class Zombie
{
    private static Random _random = new Random();
    
    public string Name { get; set; }
    public ZombieType Type { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public Zombie()
    {
        // Génère un type de zombie aléatoire
        Type = (ZombieType)_random.Next(0, Enum.GetValues(Type of (ZombieType)) lenght + 1);
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
                break;
            case ZombieType.Radioactif:
                Name = "Zombie Radioactif";
                Health = 120;
                Damage = 10;
                break;
            case ZombieType.Cuirassé:
                Name = "Zombie Cuirassé";
                Health = 200;
                Damage = 15;
                break;
            default:
                Name = "Zombie Commun";
                Health = 100;
                Damage = 12;
                break;
        }
    }
}