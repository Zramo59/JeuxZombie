# 🧟 ZOMBIE APOCALYPSE - Guide Complet

## 📖 Vue d'ensemble

**Zombie Apocalypse** est un jeu de survie en ligne de commande où vous incarnez un héros cherchant à survivre dans un monde rempli de créatures zombies. Affrontez des ennemis variés, progressez, et améliorez votre équipement pour devenir de plus en plus puissant.

---

## 🎮 Menu Principal

Le menu principal vous offre 5 options :

### 1️⃣ Commencer un combat
Lance un combat contre un zombie aléatoire. Vous rencontrerez différents types de zombies :
- **Zombie Normal** : Ennemi basique avec 100 PV
- **Zombie Radioactif** : 120 PV, inflige des dégâts supplémentaires
- **Zombie Berserk** : 80 PV mais entre en rage et augmente ses dégâts
- **Zombie Cuirassé** : 200 PV avec une armure réduisant les dégâts

### 2️⃣ Inventaire
Affiche votre inventaire avec les potions disponibles :
- **Potion Petite** : +20 PV
- **Potion Moyenne** : +50 PV
- **Potion Grande** : +100 PV

Vous pouvez utiliser les potions lors du combat ou depuis ce menu.

### 3️⃣ Armes
Consultez les informations détaillées de votre arme équipée :
- **Nom de l'arme**
- **Niveau** : S'augmente avec l'utilisation
- **Dégâts de base** : Augmente avec les niveaux d'arme
- **Dégâts actuels** : Dégâts réels = Dégâts × (Durabilité / 100)
- **Durabilité** : En % (100% = état neuf)
- **Munitions** : Si applicable (Mage)
- **Expérience** : XP vers le prochain niveau d'arme

**Actions disponibles :**
- [1] Réparer l'arme (ramène la durabilité à 100%)
- [2] Retour au menu

### 4️⃣ Sauvegarder
Sauvegarde votre progression actuelle (nom, niveau, santé, or, inventaire, arme, etc.)

### 5️⃣ Quitter le jeu
Termine le jeu.

---

## ⚔️ Système de Combat

### Déroulement

1. **Initiative** : Un dé détermine qui joue en premier
2. **Boucle de combat** : Alternez entre vos tours et ceux du zombie jusqu'à la fin
3. **Résultat** : Gagnez de l'expérience, de l'or, et des potions

### Actions disponibles lors de votre tour

#### [1] Attaquer
- Calcule les dégâts de votre arme en tenant compte de la durabilité
- Le zombie peut esquiver (chance aléatoire)
- L'arme perd de la durabilité (5% par utilisation)
- L'arme gagne de l'expérience (10 XP par utilisation)

**Cas spéciaux :**
- **Arme cassée** : Inflige 2 dégâts seulement
- **Mage sans mana** : Inflige 5 dégâts seulement

#### [2] Utiliser une potion
- Soigne un pourcentage de vos PV
- Ne consomme PAS votre tour si l'inventaire est vide

#### [3] Voir l'inventaire
- Affiche vos potions groupées par type
- Permet d'utiliser une potion directement
- Ne consomme PAS votre tour

#### [4] Fuir le combat
- Tentative d'échapper au combat (taux de réussite variable)
- En cas d'échec, le combat continue

### Effets spéciaux des zombies

- **Zombie Radioactif** : Inflige des dégâts supplémentaires au joueur
- **Zombie Berserk** : Entre en rage et augmente ses dégâts
- **Zombie Cuirassé** : Réduit les dégâts reçus avec son armure

---

## 📈 Système de Progression

### Expérience et Niveaux du joueur

Vous gagnez de l'XP en vainquant des zombies.

**À chaque montée de niveau :**
- ✅ +20 points de vie maximale
- ✅ Restauration à 100% de la vie
- ✅ Tous les 10 niveaux : +1 place d'inventaire

**Formule XP :**
- Niveau 1 → 100 XP
- Niveau 2 → 150 XP
- Niveau 3 → 200 XP
- Et ainsi de suite...

### Progression des armes

Les armes gagnent de l'expérience avec chaque utilisation.

**À chaque montée de niveau d'arme :**
- +5 dégâts de base
- +20% de durabilité (restaurée partiellement)
- XP réinitialisé pour le prochain niveau

---

## 💰 Système d'Or

Vous gagnez de l'or en vainquant les zombies. Actuellement, l'or est affiché mais peut être utilisé pour des améliorations futures.

---

## 🛡️ Système d'Armes

### Durabilité

- Chaque attaque réduit la durabilité de 5%
- Quand la durabilité atteint 0%, l'arme est cassée et inflige peu de dégâts
- **Réparer** ramène la durabilité à 100%

### Dégâts réels

Les dégâts réels dépendent de la durabilité :

```
Dégâts actuels = Dégâts de base × (Durabilité / 100)
```

**Exemple :**
- Épée : 25 dégâts
- Durabilité : 50%
- Dégâts réels = 25 × 0.5 = 12 dégâts

---

## 🎯 Classe du Joueur

Vous choisissez une classe au démarrage :

### Tank
- **PV de base** : 200
- **Arme** : Hache de guerre (15 dégâts)
- **Description** : Guerrier robuste, spécialisé dans la défense

### Knight
- **PV de base** : 120
- **Arme** : Épée longue (25 dégâts)
- **Description** : Combattant équilibré, alliant force et agilité

### Mage
- **PV de base** : 75
- **Arme** : Bâton magique (10 dégâts, 50 mana/munitions)
- **Description** : Utilisateur de magie puissant, inflignant des dégâts à distance

---

## 🏥 Santé et Potions

### Potions de départ
Vous commencez avec 3 potions :
- 1x Potion Petite
- 1x Potion Moyenne
- 1x Potion Grande

### Utilisation
- Les potions soignent un montant fixe de PV
- Elles ne peuvent pas surcharger votre PV au-delà du maximum
- Vous pouvez les utiliser en combat ou depuis l'inventaire

### Capacité d'inventaire
- **De départ** : 5 places
- **À chaque 10 niveaux** : +1 place

---

## 💾 Sauvegarde et Chargement

Le jeu détecte automatiquement si vous avez une partie sauvegardée au démarrage.

**Les éléments sauvegardés :**
- Nom du personnage
- Classe (Type)
- Santé actuelle
- Bonus de PV max
- Or disponible
- Arme équipée (avec niveau, XP, durabilité)
- Inventaire complet (potions)
- Expérience et niveau du joueur

---

## 🎵 Conseils de Survie

1. **Gérez votre durabilité** : Réparez votre arme régulièrement pour maximiser les dégâts
2. **Économisez les potions** : Les combat peuvent être difficiles, gardez les potions pour les moments critiques
3. **Progressez régulièrement** : Chaque niveau augmente votre vie max de 20 PV
4. **Attention aux armes cassées** : Une arme cassée inflige très peu de dégâts
5. **Diversifiez vos actions** : Utilisez fuir, potions et attaques stratégiquement

---

## 📊 Statistiques et Affichage

### Barre de santé
- 🟩 **Vert** : Plus de 50% de santé
- 🟨 **Jaune** : Entre 25% et 50%
- 🟥 **Rouge** : Moins de 25%

### Barre de durabilité (arme)
- 🟩 **Vert** : Plus de 50%
- 🟨 **Jaune** : Entre 25% et 50%
- 🟥 **Rouge** : Moins de 25%

---

## 🐛 Dépannage

### L'arme ne fait pas de dégâts
- Vérifiez la durabilité : Si elle est à 0%, l'arme est cassée
- Solution : Allez dans le menu Armes et réparez l'arme

### Pas de potions disponibles
- Vous avez peut-être utilisé toutes vos potions
- Solution : Éliminez plus de zombies pour en obtenir de nouvelles en butin

### Sauvegarde introuvable
- Le jeu crée une nouvelle partie si aucune sauvegarde n'existe
- Assurez-vous d'avoir choisi l'option [3] Sauvegarder au menu principal

---

## 🔮 Améliorations Futures

- Système de boutique pour acheter des potions avec de l'or
- Plusieurs armes à équiper
- Compétences spéciales par classe
- Boss zombies spéciaux
- Système d'amélioration d'armes avec or

---

**Bon courage, héros ! La survie n'est qu'une question de stratégie et de chance.** 🧟‍♂️⚔️

