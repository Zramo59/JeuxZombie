﻿namespace JeuxZombie;

public class Xp
{
    public int Level { get; set; } = 1;
    public int CurrentXp { get; set; } = 0;
    public int XpToNextLevel { get; set; } = 100;
    public Player? Player { get; set; } // Référence au joueur pour les bonus de level up
    
    public void GainXp(int amount)
    {
        CurrentXp += amount;
        UIHelper.DisplaySuccess($"Vous avez gagne {amount} XP ! (XP: {CurrentXp}/{XpToNextLevel})");
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        while (CurrentXp >= XpToNextLevel)
        {
            CurrentXp -= XpToNextLevel;
            Level++;
            XpToNextLevel = CalculateXpForNextLevel();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  [!!!] LEVEL UP ! Vous etes passe au niveau {Level} !");
            Console.ResetColor();
            ApplyLevelUpBonuses();
            DisplayXp();
        }
    }

    private void ApplyLevelUpBonuses()
    {
        if (Player == null) return;

        // Augmenter le PV max de 20 points par level
        int healthIncrease = 20;
        Player.MaxHealthBonus += healthIncrease;
        int newMaxHealth = Player.GetMaxHealth();
        Player.Health = newMaxHealth; // Restaurer la vie au nouveau maximum
        UIHelper.DisplaySuccess($"  +{healthIncrease} PV max ! (PV max: {newMaxHealth})");

        // Tous les 10 niveaux, ajouter une place d'inventaire
        if (Level % 10 == 0)
        {
            Player.Inventory.IncreaseCapacity();
            UIHelper.DisplaySuccess($"  Capacité d'inventaire augmentée ! Nouvelle capacité: {Player.Inventory.GetMaxCapacity()}");
        }
    }

    private int CalculateXpForNextLevel()
    {
        return 100 + (Level - 1) * 50;
    }
    
    public void DisplayXp()
    {
        if (XpToNextLevel == 0) XpToNextLevel = CalculateXpForNextLevel();
        UIHelper.DisplayColoredBar("[*] XP - Niveau " + Level, CurrentXp, XpToNextLevel, ConsoleColor.Blue);
    }
}