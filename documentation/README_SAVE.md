# Système de Sauvegarde - JeuxZombie

## Fonctionnalités

Le système de sauvegarde permet maintenant de :
- **Sauvegarder votre partie** à tout moment depuis le menu principal
- **Charger une partie existante** au démarrage du jeu
- **Reprendre là où vous vous étiez arrêté** avec tous vos progrès

## Comment utiliser

### Sauvegarder votre partie
1. Dans le menu principal, appuyez sur **3** pour "Save Game"
2. Votre partie sera sauvegardée automatiquement
3. Un message de confirmation s'affichera

### Charger une partie
1. Lancez le jeu
2. Si une sauvegarde existe, vous verrez un menu :
   - **1** - Charger la partie sauvegardée
   - **2** - Nouvelle partie
3. Appuyez sur **1** pour charger votre partie

### Données sauvegardées
Le système sauvegarde :
- ✓ Nom du personnage
- ✓ Classe (Tank, Knight, Mage)
- ✓ Points de vie actuels
- ✓ Niveau et expérience
- ✓ Arme équipée (modèle, dégâts, munitions, durabilité, niveau, XP)
- ✓ Inventaire complet (toutes les potions)
- ✓ Date et heure de la sauvegarde

### Emplacement de la sauvegarde
Les fichiers de sauvegarde sont stockés dans :
```
%USERPROFILE%\Documents\JeuxZombie\Saves\save.json
```

### Format de sauvegarde
Les sauvegardes utilisent le format JSON pour une lisibilité et une portabilité optimales.

## Commandes du menu principal

- **1** - Start Fight : Commencer un combat contre un zombie
- **2** - Inventory : Accéder à votre inventaire
- **3** - Save Game : Sauvegarder votre partie
- **4** - Left Game : Quitter le jeu

## Notes
- Une seule sauvegarde peut exister à la fois
- Créer une nouvelle partie écrase l'ancienne sauvegarde
- Les données sont sauvegardées localement sur votre ordinateur

