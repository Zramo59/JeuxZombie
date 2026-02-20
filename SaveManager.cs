﻿using System.Text.Json;

namespace JeuxZombie
{
    public class SaveData
    {
        public string PlayerName { get; set; } = string.Empty;
        public PlayerType PlayerType { get; set; }
        public int PlayerHealth { get; set; }
        public int PlayerGold { get; set; }
        public int PlayerLevel { get; set; }
        public int PlayerCurrentXp { get; set; }
        public int PlayerXpToNextLevel { get; set; }
        public string WeaponModel { get; set; } = string.Empty;
        public int WeaponDamage { get; set; }
        public int WeaponAmmo { get; set; }
        public int WeaponDurability { get; set; }
        public int WeaponLevel { get; set; }
        public int WeaponXp { get; set; }
        public List<PotionType> PotionTypes { get; set; } = new List<PotionType>();
        public DateTime SaveDate { get; set; }
    }

    public static class SaveManager
    {
        private static readonly string SaveDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "JeuxZombie",
            "Saves"
        );
        private static readonly string SaveFilePath = Path.Combine(SaveDirectory, "save.json");

        static SaveManager()
        {
            // Créer le dossier de sauvegarde s'il n'existe pas
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }
        }

        public static bool SaveGame(Player player)
        {
            try
            {
                var saveData = new SaveData
                {
                    PlayerName = player.Name,
                    PlayerType = player.Type,
                    PlayerHealth = player.Health,
                    PlayerGold = player.Gold,
                    PlayerLevel = player.Xp.Level,
                    PlayerCurrentXp = player.Xp.CurrentXp,
                    PlayerXpToNextLevel = player.Xp.XpToNextLevel,
                    WeaponModel = player.CurrentWeapon.Model,
                    WeaponDamage = player.CurrentWeapon.Damage,
                    WeaponAmmo = player.CurrentWeapon.Ammo,
                    WeaponDurability = player.CurrentWeapon.Durability,
                    WeaponLevel = player.CurrentWeapon.Level,
                    WeaponXp = player.CurrentWeapon.Xp,
                    PotionTypes = player.Inventory.GetAllPotionTypes(),
                    SaveDate = DateTime.Now
                };

                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(saveData, options);
                File.WriteAllText(SaveFilePath, jsonString);

                UIHelper.DisplaySuccess($"Partie sauvegardée avec succès !");
                UIHelper.DisplayInfo($"Localisation : {SaveFilePath}");
                return true;
            }
            catch (Exception ex)
            {
                UIHelper.DisplayError($"Erreur lors de la sauvegarde : {ex.Message}");
                return false;
            }
        }

        public static Player? LoadGame()
        {
            try
            {
                if (!File.Exists(SaveFilePath))
                {
                    UIHelper.DisplayError("Aucune sauvegarde trouvée.");
                    return null;
                }

                string jsonString = File.ReadAllText(SaveFilePath);
                SaveData? saveData = JsonSerializer.Deserialize<SaveData>(jsonString);

                if (saveData == null)
                {
                    UIHelper.DisplayError("Impossible de charger la sauvegarde.");
                    return null;
                }

                // Créer le joueur avec les données sauvegardées
                Player player = new Player(saveData.PlayerName, saveData.PlayerType);
                
                // Restaurer les stats
                player.Health = saveData.PlayerHealth;
                player.Gold = saveData.PlayerGold;
                
                // Restaurer l'XP et le niveau
                player.Xp.Level = saveData.PlayerLevel;
                player.Xp.CurrentXp = saveData.PlayerCurrentXp;
                player.Xp.XpToNextLevel = saveData.PlayerXpToNextLevel;
                
                // Restaurer l'arme
                player.CurrentWeapon = new Weapon(saveData.WeaponModel, saveData.WeaponDamage, saveData.WeaponAmmo);
                player.CurrentWeapon.Durability = saveData.WeaponDurability;
                player.CurrentWeapon.Level = saveData.WeaponLevel;
                player.CurrentWeapon.Xp = saveData.WeaponXp;
                
                // Restaurer l'inventaire
                player.Inventory.ClearInventory();
                foreach (var potionType in saveData.PotionTypes)
                {
                    var potion = new Potion();
                    potion.InitialisePotion(potionType);
                    player.Inventory.AddPotion(potion);
                }

                UIHelper.DisplaySuccess("Partie chargée avec succès !");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"  📅 Date de sauvegarde : {saveData.SaveDate:dd/MM/yyyy HH:mm:ss}");
                Console.WriteLine($"  🧑 Joueur : {player.Name} (Niveau {player.Xp.Level})");
                Console.ResetColor();
                return player;
            }
            catch (Exception ex)
            {
                UIHelper.DisplayError($"Erreur lors du chargement : {ex.Message}");
                return null;
            }
        }

        public static bool HasSaveFile()
        {
            return File.Exists(SaveFilePath);
        }

        public static void DeleteSave()
        {
            try
            {
                if (File.Exists(SaveFilePath))
                {
                    File.Delete(SaveFilePath);
                    UIHelper.DisplaySuccess("Sauvegarde supprimée.");
                }
            }
            catch (Exception ex)
            {
                UIHelper.DisplayError($"Erreur lors de la suppression : {ex.Message}");
            }
        }
    }
}

