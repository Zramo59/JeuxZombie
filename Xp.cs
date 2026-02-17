namespace JeuxZombie;

public class Xp
{
        public int Level { get; private set; }
        public int CurrentXp { get; private set; }
        public int XpToNextLevel { get; private set; }
        
    
        public void GainXp(int amount)
        {
            CurrentXp += amount;
            Console.WriteLine($"✓ Vous avez gagné {amount} XP ! (XP: {CurrentXp}/{XpToNextLevel})");
            CheckLevelUp();
        }
    
        private void CheckLevelUp()
        {
            while (CurrentXp >= XpToNextLevel)
            {
                CurrentXp -= XpToNextLevel;
                Level++;
                XpToNextLevel = CalculateXpForNextLevel();
                Console.WriteLine($"🎉 Félicitations ! Vous êtes passé au niveau {Level} !");
            }
        }
    
        private int CalculateXpForNextLevel()
        {
            return 100 + (Level - 1) * 50; // Exemple de formule d'XP croissante
        }
        
        // public static void DisplayXp()
        // {
        //     Console.WriteLine($"Niveau: {Level} | XP: {CurrentXp}/{XpToNextLevel}");
        // }
}