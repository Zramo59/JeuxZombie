﻿namespace JeuxZombie
{
    public enum PotionType
    {
        Small,
        Medium,
        Large
    }

    public class Potion
    {
        public PotionType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public int HealAmount { get; set; }

        public void InitialisePotion(PotionType type)
        {
            Type = type;
            switch (type)
            {
                case PotionType.Small:
                    Name = "Potion Petite";
                    HealAmount = 20;
                    break;
                case PotionType.Medium:
                    Name = "Potion Moyenne";
                    HealAmount = 50;
                    break;
                case PotionType.Large:
                    Name = "Potion Grande";
                    HealAmount = 100;
                    break;
            }
        }
    }

    public class Inventory
    {
        private List<Potion> _potions;
        private int _maxCapacity;

        public Inventory(int maxCapacity)
        {
            _potions = new List<Potion>();
            _maxCapacity = maxCapacity;
        }

        public bool AddPotion(Potion potion)
        {
            if (_potions.Count >= _maxCapacity)
            {
                Console.WriteLine("Inventaire plein !");
                return false;
            }

            _potions.Add(potion);
            return true;
        }

        public void DisplayInventory(Player player)
        {
            bool inInventory = true;
            while (inInventory)
            {
                Console.Clear();
                UIHelper.DisplayTitle($"🎒 INVENTAIRE ({_potions.Count}/{_maxCapacity})");

                var grouped = _potions.GroupBy(p => p.Type).OrderBy(g => g.Key);

                int index = 1;
                var potionList = new List<Potion>();
                
                if (grouped.Any())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  ═══════════════════════════════════════\n");
                    Console.ResetColor();
                    
                    foreach (var group in grouped)
                    {
                        UIHelper.DisplayMenuItem(index, $"{group.First().Name} (+{group.First().HealAmount} PV) x{group.Count()}");
                        potionList.Add(group.First());
                        index++;
                    }
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n  ═══════════════════════════════════════");
                    Console.ResetColor();
                }
                else
                {
                    UIHelper.DisplayWarning("Votre inventaire est vide !");
                    Console.WriteLine();
                    index = 1;
                }
                
                UIHelper.DisplayMenuItem(index, "Retour au menu");
                Console.WriteLine();
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  ══════════════════════════════════════");
                Console.ResetColor();
                HealthManager.DisplayHealthBarPlayer(player);
                player.Xp.DisplayXp();
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  💰 Or disponible : {player.Gold} pièces");
                Console.ResetColor();
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  ══════════════════════════════════════\n");
                Console.ResetColor();
                
                UIHelper.DisplayPrompt("Quelle action voulez-vous effectuer ?");
                ConsoleKeyInfo actionKey = Console.ReadKey(true);

                if (char.IsDigit(actionKey.KeyChar))
                {
                    int choice = int.Parse(actionKey.KeyChar.ToString());
                    
                    if (choice >= 1 && choice < index)
                    {
                        Potion selectedPotion = potionList[choice - 1];
                        if (HealthManager.UsePotion(player, selectedPotion.Type))
                        {
                            RemovePotion(selectedPotion);
                        }
                        UIHelper.PressAnyKey();
                    }
                    else if (choice == index)
                    {
                        UIHelper.DisplayMessage("Retour au menu...", "👈");
                        inInventory = false;
                    }
                    else
                    {
                        UIHelper.DisplayError("Choix invalide !");
                        UIHelper.PressAnyKey();
                    }
                }
                else
                {
                    UIHelper.DisplayError("Entrée invalide !");
                    UIHelper.PressAnyKey();
                }
            }
        }
        
        public bool RemovePotion(Potion potion)
        {
            return _potions.Remove(potion);
        }
        
        public bool AddToInventory(Potion potion)
        {
            if (_potions.Count >= _maxCapacity)
            {
                return false;
            }

            _potions.Add(potion);
            return true;
        }
        
        public bool IsFull => _potions.Count >= _maxCapacity;

        public bool IsEmpty => !_potions.Any();

        public Potion? GetPotion(PotionType type)
        {
            return _potions.FirstOrDefault(p => p.Type == type);
        }

        public Potion? GetAnyPotion()
        {
            return _potions.FirstOrDefault();
        }

        public List<PotionType> GetAllPotionTypes()
        {
            return _potions.Select(p => p.Type).ToList();
        }

        public void ClearInventory()
        {
            _potions.Clear();
        }

        public void IncreaseCapacity()
        {
            _maxCapacity++;
        }

        public int GetMaxCapacity()
        {
            return _maxCapacity;
        }
    }
}
