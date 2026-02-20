namespace JeuxZombie
{
    public static class AnimationHelper
    {
        // Effet de "clignotement" du texte
        public static void BlinkText(string text, ConsoleColor color, int times = 3, int delayMs = 200)
        {
            for (int i = 0; i < times; i++)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                System.Threading.Thread.Sleep(delayMs);
                
                // Effacer le texte
                Console.Write(new string('\b', text.Length));
                Console.Write(new string(' ', text.Length));
                Console.Write(new string('\b', text.Length));
                
                System.Threading.Thread.Sleep(delayMs);
            }
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        // Afficher une progression
        public static void ShowLoadingBar(string message = "Chargement", int duration = 3)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"\n  {message} ");
            Console.ResetColor();

            int steps = 20;
            int delayPerStep = (duration * 1000) / steps;

            for (int i = 0; i < steps; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("█");
                Console.ResetColor();
                System.Threading.Thread.Sleep(delayPerStep);
            }
            Console.WriteLine(" ✅\n");
        }

        // Animation de dégâts
        public static void AnimateDamage(int amount)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n  💥 -{amount} PV 💥");
            Console.ResetColor();
            System.Threading.Thread.Sleep(500);
        }

        // Animation de soin
        public static void AnimateHealing(int amount)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n  ✨ +{amount} PV ✨");
            Console.ResetColor();
            System.Threading.Thread.Sleep(500);
        }

        // Animation de victoire
        public static void AnimateVictory()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\n  🎉🎉🎉  VICTOIRE!  🎉🎉🎉");
                System.Threading.Thread.Sleep(300);
            }
            Console.ResetColor();
        }

        // Animation de défaite
        public static void AnimateDefeat()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\n  💀💀💀  DÉFAITE!  💀💀💀");
                System.Threading.Thread.Sleep(300);
            }
            Console.ResetColor();
        }

        // Dessiner une boîte de dialogue
        public static void DrawBox(string content, int width = 50)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  " + new string('═', width));
            
            string[] lines = content.Split('\n');
            foreach (string line in lines)
            {
                Console.WriteLine($"  ║ {line.PadRight(width - 4)} ║");
            }
            
            Console.WriteLine("  " + new string('═', width));
            Console.ResetColor();
        }

        // Animation des points de suspension (...)
        public static void AnimateDots(string prefix = "", int count = 3, int delayMs = 300)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\n  {prefix}");
            
            for (int i = 0; i < count; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(delayMs);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // Effets visuels de combat
        public static void ShowAttackEffect()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n  ⚔️  Attaque lancée!");
            Console.ResetColor();
            System.Threading.Thread.Sleep(300);
        }

        public static void ShowDefenseEffect()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n  🛡️  Défense activée!");
            Console.ResetColor();
            System.Threading.Thread.Sleep(300);
        }
    }
}

