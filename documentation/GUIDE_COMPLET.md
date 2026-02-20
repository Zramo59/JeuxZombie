# 🎮 JeuxZombie - Guide Complet

## ✨ Nouvelles Fonctionnalités Implémentées

### 🔄 Système de Sauvegarde
Un système complet de sauvegarde a été ajouté au jeu !

#### Menu principal mis à jour :
```
=== MENU ===
1 - Start Fight       → Commencer un combat
2 - Inventory         → Accéder à l'inventaire
3 - Save Game         → NOUVEAU ! Sauvegarder votre partie
4 - Left Game         → Quitter le jeu
```

#### Au démarrage du jeu :
Si une sauvegarde existe, vous verrez :
```
=== SAUVEGARDE DÉTECTÉE ===
1 - Charger la partie sauvegardée
2 - Nouvelle partie
```

### 📊 Barre d'XP Bleue
La barre d'XP s'affiche maintenant en **bleu** (comme demandé) :
- Format : `[████████████░░░░░░░░] 50/100 XP (Niveau: 3)`
- Visible dans l'inventaire et après les combats
- Mise à jour automatique après chaque gain d'XP

### 🧪 Utilisation des Potions depuis l'Inventaire
Vous pouvez maintenant **utiliser des potions directement depuis l'inventaire** !

#### Comment faire :
1. Appuyez sur **2** dans le menu principal pour ouvrir l'inventaire
2. Sélectionnez une potion en tapant son numéro (1, 2, ou 3)
3. La potion est automatiquement utilisée et retirée de l'inventaire
4. Votre barre de vie se met à jour instantanément

#### Affichage dans l'inventaire :
```
=== INVENTAIRE (3/5) ===
  1. Potion Petite (+20 PV) x2
  2. Potion Moyenne (+50 PV) x1
  3. Potion Grande (+100 PV) x1
  4. Retour au menu

[████████████████████] 120/120 PV
[████████░░░░░░░░░░░░] 40/100 XP (Niveau: 2)
```

## 📁 Données Sauvegardées

Le système sauvegarde automatiquement :
- ✅ **Personnage** : Nom, Classe, Points de vie
- ✅ **Progression** : Niveau, XP actuelle, XP pour niveau suivant
- ✅ **Équipement** : Arme (modèle, dégâts, munitions, durabilité, niveau, XP)
- ✅ **Inventaire** : Toutes les potions avec leurs types
- ✅ **Métadonnées** : Date et heure de sauvegarde

## 🗂️ Emplacement des Fichiers

### Sauvegarde :
```
%USERPROFILE%\Documents\JeuxZombie\Saves\save.json
```

Exemple sous Windows :
```
C:\Users\VotreNom\Documents\JeuxZombie\Saves\save.json
```

### Format JSON :
```json
{
  "PlayerName": "Jean",
  "PlayerType": "Knight",
  "PlayerHealth": 95,
  "PlayerLevel": 3,
  "PlayerCurrentXp": 45,
  "PlayerXpToNextLevel": 150,
  "WeaponModel": "Épée longue",
  "WeaponDamage": 30,
  "WeaponAmmo": 0,
  "WeaponDurability": 85,
  "WeaponLevel": 2,
  "WeaponXp": 40,
  "PotionTypes": ["Small", "Medium", "Large"],
  "SaveDate": "2026-02-19T14:30:00"
}
```

## 🎯 Utilisation Recommandée

### Scénario 1 : Sauvegarder avant un combat difficile
```
Menu → 3 (Save Game) → Combat → Si défaite → Relancer et charger
```

### Scénario 2 : Reprendre une partie plus tard
```
Quitter le jeu → Revenir plus tard → 1 (Charger) → Continuer
```

### Scénario 3 : Gérer ses potions intelligemment
```
Inventaire → Utiliser une petite potion → Garder les grandes pour les boss
```

## 🛠️ Fichiers Modifiés/Créés

### Nouveaux fichiers :
- `SaveManager.cs` - Gère la sauvegarde et le chargement
- `README_SAVE.md` - Documentation du système de sauvegarde
- `GUIDE_COMPLET.md` - Ce guide

### Fichiers modifiés :
- `Program.cs` - Ajout du menu de chargement et de sauvegarde
- `inventory.cs` - Ajout de méthodes pour la sauvegarde et utilisation des potions
- `Xp.cs` - Propriétés rendues publiques pour la sauvegarde

## 🎨 Codes Couleur

- **Vert** : Vie (barre de santé)
- **Bleu** : XP (barre d'expérience)
- **Rouge** : Danger (vie basse)
- **Jaune** : Attention (vie moyenne)

## 💡 Conseils de Jeu

1. **Sauvegardez régulièrement** après chaque victoire importante
2. **Utilisez les potions stratégiquement** depuis l'inventaire
3. **Surveillez votre XP** pour savoir quand vous allez monter de niveau
4. **Gardez un œil sur la durabilité** de votre arme
5. **Fuyez si nécessaire** pour sauvegarder votre progression

## 🐛 Notes Techniques

- Le système utilise la sérialisation JSON pour la sauvegarde
- Une seule sauvegarde active à la fois
- Les propriétés ont été rendues publiques pour faciliter la sérialisation
- Le dossier de sauvegarde est créé automatiquement s'il n'existe pas

---

**Bon jeu ! 🧟‍♂️⚔️**

