namespace JeuxZombie;

public class RunAway
{
    private Random _rng = new Random();

    public void Fuite()
    {
        Console.WriteLine("Vous avez choisi de fuir le combat !");
        // Logique de fuite
        bool fuiteReussie = _rng.Next(0, 2) == 0;
        if (fuiteReussie)
        {
            Console.WriteLine("✓ Vous avez réussi à fuir !");
        }
        else
        {
            Console.WriteLine("❌ La fuite a échoué ! Le combat continue.");
        }
    }

    public bool TryToFlee(Player player, Zombie zomb)
    {
        Console.WriteLine("Tentative de fuite...");
        return _rng.Next(0, 2) == 0;
    }
}