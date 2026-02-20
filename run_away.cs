﻿namespace JeuxZombie;

public class RunAway
{
    private Random _rng = new Random();

    public void Fuite()
    {
        UIHelper.DisplayMessage("Vous avez choisi de fuir le combat !", "🏃");
        // Logique de fuite
        bool fuiteReussie = _rng.Next(0, 2) == 0;
        if (fuiteReussie)
        {
            UIHelper.DisplaySuccess("Vous avez réussi à fuir !");
        }
        else
        {
            UIHelper.DisplayError("La fuite a échoué ! Le combat continue.");
        }
    }

    public bool TryToFlee(Player player, Zombie zomb)
    {
        UIHelper.DisplayMessage("Tentative de fuite...", "🏃");
        return _rng.Next(0, 2) == 0;
    }
}