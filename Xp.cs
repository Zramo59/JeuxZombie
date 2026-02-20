namespace JeuxZombie;

public class Xp
{
        public int Level { get; set; } = 1;
        public int CurrentXp { get; set; }
        public int XpToNextLevel { get; set; }
        
    
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
        
        public void DisplayXp()
        {
            if (XpToNextLevel == 0) XpToNextLevel = CalculateXpForNextLevel();

            double xpPercent = XpToNextLevel > 0 ? (double)CurrentXp / XpToNextLevel : 0;
            int barLength = 20;
            int filledBars = (int)(xpPercent * barLength);

            string bar = "[" + new string('█', filledBars) + new string('░', Math.Max(0, barLength - filledBars)) + "]";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{bar} {CurrentXp}/{XpToNextLevel} XP (Niveau: {Level})");
            Console.ResetColor();
            Console.WriteLine();
        }
}