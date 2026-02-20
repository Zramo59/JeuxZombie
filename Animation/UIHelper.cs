namespace JeuxZombie
{
    public static class UIHelper
    {
        // Couleurs pour l'UI
        private static readonly ConsoleColor PRIMARY_COLOR = ConsoleColor.Cyan;
        private static readonly ConsoleColor ACCENT_COLOR = ConsoleColor.Yellow;
        private static readonly ConsoleColor SUCCESS_COLOR = ConsoleColor.Green;
        private static readonly ConsoleColor ERROR_COLOR = ConsoleColor.Red;
        private static readonly ConsoleColor ZOMBIE_COLOR = ConsoleColor.DarkRed;
        private static readonly ConsoleColor PLAYER_COLOR = ConsoleColor.Blue;

        // Méthode pour afficher un titre de menu
        public static void DisplayTitle(string title)
        {
            Console.Clear();
            Console.ForegroundColor = PRIMARY_COLOR;
            Console.WriteLine("\n" + new string('═', 50));
            Console.WriteLine($"  ║  {title.PadRight(45)}  ║");
            Console.WriteLine(new string('═', 50) + "\n");
            Console.ResetColor();
        }

        // Méthode pour afficher une option de menu
        public static void DisplayMenuItem(int number, string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = ACCENT_COLOR;
            Console.Write($"  [{number}] ");
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        // Méthode pour afficher un séparateur
        public static void DisplaySeparator()
        {
            Console.ForegroundColor = PRIMARY_COLOR;
            Console.WriteLine(new string('─', 50));
            Console.ResetColor();
        }

        // Afficher un message de succès
        public static void DisplaySuccess(string message)
        {
            Console.ForegroundColor = SUCCESS_COLOR;
            Console.WriteLine($"  [OK] {message}");
            Console.ResetColor();
        }

        // Afficher un message d'erreur
        public static void DisplayError(string message)
        {
            Console.ForegroundColor = ERROR_COLOR;
            Console.WriteLine($"  [X] {message}");
            Console.ResetColor();
        }

        // Afficher un message d'avertissement
        public static void DisplayWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  [!] {message}");
            Console.ResetColor();
        }

        // Afficher un message d'information
        public static void DisplayInfo(string message)
        {
            Console.ForegroundColor = PRIMARY_COLOR;
            Console.WriteLine($"  [i] {message}");
            Console.ResetColor();
        }

        // Afficher un message neutre avec une icône
        public static void DisplayMessage(string message, string icon = "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  {icon} {message}");
            Console.ResetColor();
        }

        // Afficher un prompt pour l'input
        public static void DisplayPrompt(string text)
        {
            Console.ForegroundColor = ACCENT_COLOR;
            Console.Write($"\n  >> {text} ");
            Console.ResetColor();
        }

        // Afficher une barre de progression avec couleur
        public static void DisplayColoredBar(string label, int current, int max, ConsoleColor barColor = ConsoleColor.Green)
        {
            // Valider les entrées
            current = Math.Max(0, current);
            max = Math.Max(1, max);
            
            int barLength = 30;
            int filledLength = (int)((double)current / max * barLength);
            filledLength = Math.Min(barLength, Math.Max(0, filledLength)); // Limiter entre 0 et barLength
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"  {label.PadRight(15)} |");
            
            Console.ForegroundColor = barColor;
            Console.Write(new string('=', filledLength));
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(new string('-', barLength - filledLength));
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"| {current}/{max}");
            Console.ResetColor();
        }

        // Menu de sélection avec navigation (flèches + numéros)
        public static int DisplaySelectiveMenu(string[] options)
        {
            int selectedIndex = 0;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");

                for (int i = 0; i < options.Length; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.ForegroundColor = ACCENT_COLOR;
                            Console.Write("  > ");
                            Console.ForegroundColor = SUCCESS_COLOR;
                            Console.WriteLine($"[{i + 1}] {options[i]}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine($"    [{i + 1}] {options[i]}");
                        }
                    }

                Console.ResetColor();
                Console.ForegroundColor = ACCENT_COLOR;
                Console.WriteLine("\n  (Utilisez les flèches ou les chiffres pour choisir, puis Entrée)");
                Console.ResetColor();

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % options.Length;
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return selectedIndex;
                }
                else if (char.IsDigit(key.KeyChar))
                {
                    int choice = int.Parse(key.KeyChar.ToString()) - 1;
                    if (choice >= 0 && choice < options.Length)
                    {
                        return choice;
                    }
                }
            }
        }

        // Afficher les stats du joueur de manière colorée
        public static void DisplayPlayerStats(Player player)
        {
            Console.ForegroundColor = PLAYER_COLOR;
            Console.WriteLine("\n  ╔═══════════════════════════════════════╗");
            Console.WriteLine($"  ║ Héros: {player.Name.PadRight(32)} ║");
            Console.WriteLine($"  ║ Classe: {player.Type.ToString().PadRight(30)} ║");
            Console.WriteLine("  ╚═══════════════════════════════════════╝");
            Console.ResetColor();
        }

        // Afficher un combat stylisé
        public static void DisplayCombatHeader(Player player, Zombie zombie)
        {
            Console.ForegroundColor = ERROR_COLOR;
            Console.WriteLine("\n" + new string('═', 50));
            Console.ForegroundColor = PLAYER_COLOR;
            Console.Write($"  {player.Name.PadRight(20)}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" VS ");
            Console.ForegroundColor = ZOMBIE_COLOR;
            Console.WriteLine(zombie.Name.PadLeft(20));
            Console.ForegroundColor = ERROR_COLOR;
            Console.WriteLine(new string('═', 50) + "\n");
            Console.ResetColor();
        }

        // Écrire du texte avec délai (effet machine à écrire)
        public static void DisplayTypingEffect(string text, int delayMs = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        // Afficher une bannière centrale
        public static void DisplayBanner(string text)
        {
            int bannerWidth = 50;
            int padding = (bannerWidth - text.Length - 2) / 2;
            
            Console.ForegroundColor = PRIMARY_COLOR;
            Console.WriteLine("\n" + new string('═', bannerWidth));
            Console.WriteLine($"{new string(' ', padding)}► {text} ◄");
            Console.WriteLine(new string('═', bannerWidth) + "\n");
            Console.ResetColor();
        }

        // Afficher les informations d'un ennemi
        public static void DisplayEnemyInfo(Zombie zombie)
        {
            Console.ForegroundColor = ZOMBIE_COLOR;
            Console.WriteLine("\n  ╔═══════════════════════════════════════╗");
            Console.WriteLine($"  ║ Ennemi: {zombie.Name.PadRight(29)} ║");
            Console.WriteLine($"  ║ Force: {zombie.Damage.ToString().PadRight(31)} ║");
            Console.WriteLine("  ╚═══════════════════════════════════════╝\n");
            Console.ResetColor();
        }

        // Afficher un menu avec largeur dynamique
        public static void DisplayMenu(string title, string[] options)
        {
            DisplayTitle(title);
            for (int i = 0; i < options.Length; i++)
            {
                DisplayMenuItem(i + 1, options[i]);
            }
            DisplayPrompt("Choisissez une option:");
        }

        // Pause avec message
        public static void PressAnyKey(string message = "Appuyez sur une touche pour continuer...")
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\n  {message}");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }
}

