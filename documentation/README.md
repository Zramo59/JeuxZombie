# JeuxZombie - Jeu de Combat en Terminal

Un jeu de combat RPG en ligne de commande où vous combattez des zombies, gagnez de l'expérience et collectez du butin !

## 🎮 Vue d'Ensemble

**JeuxZombie** est un jeu d'aventure textuel où vous incarnez un héros survivant dans un monde envahi par les zombies. Combattez différents types de zombies, améliorez votre niveau, collectez des armes et des potions pour survivre !

---

## ⚙️ Système de Jeu

### 📋 Classes de Personnages

Trois classes disponibles au démarrage :

#### 1. **🛡️ TANK** (Défenseur Robuste)
- **Santé** : 200 HP
- **Arme de départ** : Hache de guerre (15 dégâts)
- **Style** : Robuste et résistant, spécialisé dans la défense
- **Avantage** : Plus de santé, esquive faible (10%)

#### 2. **⚔️ KNIGHT** (Combattant Équilibré)
- **Santé** : 120 HP
- **Arme de départ** : Épée longue (25 dégâts)
- **Style** : Alliant force et agilité
- **Avantage** : Équilibré, esquive moyenne (25%)

#### 3. **✨ MAGE** (Utilisateur de Magie)
- **Santé** : 75 HP
- **Arme de départ** : Bâton magique (10 dégâts + 50 mana)
- **Style** : Puissant mais fragile
- **Avantage** : Dégâts magiques, esquive élevée (35%)

### 🧟 Types de Zombies

Quatre types de zombies rencontrables :

#### 1. **Zombie Normal**
- **Santé** : 100 HP
- **Dégâts** : 12 par attaque
- **Esquive** : 20%
- **XP** : 5-15 points
- **Effet spécial** : Aucun

#### 2. **🔥 Zombie Berserk** (Agressif)
- **Santé** : 80 HP
- **Dégâts** : 25 par attaque (augmente à 35 si santé < 40)
- **Esquive** : 15%
- **XP** : 15-25 points
- **Effet spécial** : Entre en RAGE quand sa vie est basse → dégâts +10

#### 3. **☢️ Zombie Radioactif** (Toxique)
- **Santé** : 120 HP
- **Dégâts** : 10 par attaque + 5 dégâts de radiation
- **Esquive** : 25%
- **XP** : 20-30 points
- **Effet spécial** : Inflige 5 dégâts supplémentaires de radiation par tour

#### 4. **🛡️ Zombie Cuirassé** (Blindé)
- **Santé** : 200 HP
- **Dégâts** : 15 par attaque
- **Esquive** : 10%
- **XP** : 25-30 points
- **Effet spécial** : Absorbe 20% des dégâts reçus grâce à son armure

---

## 🎯 Mécanique de Combat

### Tour de Combat

1. **Vous attaquez d'abord** ou **l'ennemi** (aléatoire avec initiative)
2. **Vous choisissez une action** :
   - `[1] Attaquer` : Infliger des dégâts
   - `[2] Utiliser une potion` : Récupérer de la vie
   - `[3] Voir l'inventaire` : Gérer vos potions
   - `[4] Fuir le combat` : Tenter de s'échapper (50% de chance)

3. **L'ennemi attaque** (s'il n'a pas été vaincu)

### 🛡️ Système d'Esquive

Chaque attaque peut être esquivée !

- **Joueur** : Chance d'esquive basée sur sa classe (10-35%)
- **Zombie** : Chance d'esquive basée sur son type (10-25%)

Exemple : 
```
>> Le Zombie Radioactif a esquive votre attaque !
```

### 💥 Dégâts et Réductions

Les dégâts varient selon :
- **Votre arme** : Dégâts de base + variation aléatoire
- **Armure du zombie** : Réduit les dégâts de 20% (Cuirassé seulement)
- **État du zombie** : Berserk augmente ses dégâts à -40 HP

---

## 💎 Système d'Inventaire

### 📦 Capacité
- **Limite** : 5 potions maximum
- **Gestion** : Appuyez sur `[3]` pendant le combat pour accéder à l'inventaire

### 🧪 Types de Potions

| Nom | Récupération | Fréquence |
|-----|--------------|-----------|
| Potion Petite | +20 PV | Commune |
| Potion Moyenne | +50 PV | Moyenne |
| Potion Grande | +100 PV | Rare |

### 🎁 Potions de Départ
Vous commencez avec :
- 1x Potion Petite
- 1x Potion Moyenne
- 1x Potion Grande

---

## ⭐ Système d'Expérience (XP)

### Progression
- **XP de départ** : 0 / 100
- **Formule** : XP requis = 100 + (Niveau - 1) × 50
  - Niveau 1 → 2 : 100 XP
  - Niveau 2 → 3 : 150 XP
  - Niveau 3 → 4 : 200 XP
  - etc...

### Gains d'XP
Chaque victoire en combat vous rapporte :
- **XP variables** selon le type de zombie (5-30 XP)
- **Affichage** : Visible dans l'écran de victoire

### Montée de Niveau
Lorsque vous gagnez assez d'XP :
```
  [!!!] LEVEL UP ! Vous etes passe au niveau 2 !
  [*] XP - Niveau 2 |=========----------| 0/150
```

---

## 💰 Système de Butin

### 70% de chance de loot après chaque victoire

#### Types de Butin

1. **🧪 Potion** (Aléatoire)
   - Une potion aléatoire s'ajoute à votre inventaire
   - Alerte si inventaire plein

2. **⚔️ Arme** (Aléatoire)
   - Épée Rouillée (15 dégâts)
   - Dague Acérée (20 dégâts)
   - Massue Lourde (18 dégâts)
   - Arc Ancien (22 dégâts)
   - Bâton Pétrifié (25 dégâts)
   - Variation aléatoire : +0 à +10 dégâts
   - Remplace votre arme que si elle est meilleure

3. **💰 Or** (10-50 pièces)
   - S'ajoute à votre trésor total
   - Affiché au menu principal

---

## 🎮 Interface Utilisateur

### Menu Principal
```
═══════════════════════════════════════════════════════
  ║  MENU PRINCIPAL                                     ║
═══════════════════════════════════════════════════════

  [*] Or disponible : 75 pieces

  [1] Commencer un combat
  [2] Inventaire
  [3] Sauvegarder
  [4] Quitter le jeu
```

### Écran de Combat
```
  +════════════════════════════════════════════════════════+
  |  Hero               VS Zombie Berserk                |
  +════════════════════════════════════════════════════════+

  Vie             |===========================-------| 100/120

  Ennemi          |==========================--------| 80/80

  [1] Attaquer
  [2] Utiliser une potion
  [3] Voir l'inventaire
  [4] Fuir le combat
```

### Affichage des Barres de Santé
- **|** = Bordure gauche
- **=** = Santé restante (couleur dynamique)
- **-** = Santé perdue
- **|** = Bordure droite
- **X/Y** = Santé actuelle / Santé maximale

**Couleurs** :
- 🟢 **Vert** : > 50% santé
- 🟡 **Jaune** : 25-50% santé
- 🔴 **Rouge** : < 25% santé

---

## 💾 Sauvegarde et Chargement

### Système de Sauvegarde
- **Emplacement** : `C:\Users\[User]\Documents\JeuxZombie\Saves\save.json`
- **Données sauvegardées** :
  - Nom et classe du personnage
  - Santé actuelle
  - Niveau et XP
  - Arme équipée
  - Inventaire (potions)
  - Or total

### Au Lancement du Jeu
- Si une sauvegarde existe → choix : charger ou créer une nouvelle partie
- Si pas de sauvegarde → création automatique d'une nouvelle partie

### Charger une Partie
```
[OK] Partie chargee avec succes !
[i] Date de sauvegarde : 20/02/2026 14:30:45
[i] Joueur : Hero (Niveau 5)
```

---

## 🎯 Objectifs et Stratégies

### Objectif Principal
**Survivre et progresser** : Gagnez du XP, montez de niveau et devenez plus puissant !

### Conseils Stratégiques

#### Pour les Tank
- Utilisez votre santé élevée pour absorber les dégâts
- Mieux vaut attaquer que fuir
- Esquive faible = compenser par la défense

#### Pour les Knight
- Équilibre attaque/défense
- Pouvez fuir si nécessaire
- Utilisez les potions stratégiquement

#### Pour les Mage
- Dégâts magiques forts mais peu de santé
- Esquive élevée = prenez l'avantage
- Utilisez les potions souvent
- Gérez votre mana (munitions)

### Gestion de l'Inventaire
- Gardez toujours au moins 1-2 slots libres
- Utilisez les potions petites en premier (moins gaspillage)
- Réservez les grandes potions pour les moments critiques

### Équipement Optimal
- Cherchez à obtenir les armes les plus fortes
- Chaque nouvelle arme remplace la précédente si meilleure
- L'or collecté est juste informatif (pas encore utilisé en jeu)

---

## ⌨️ Commandes Principales

| Action | Touche |
|--------|--------|
| Sélectionner une option | `1`, `2`, `3`, `4` |
| Continuer | N'importe quelle touche |
| Fuir le combat | `4` pendant le combat |
| Accéder à l'inventaire | `3` pendant le combat |

---

## 📊 Progression Typique

1. **Début** : Tank/Knight/Mage Niveau 1 (0/100 XP)
2. **1-2 Combats** : Gagnez 15-30 XP
3. **Après 4-7 combats** : Niveau 2 (100+ XP)
4. **Armes** : Trouvez progressivement des meilleures armes
5. **Potions** : Collectez du butin pour remplir votre inventaire
6. **Or** : Accumulez des pièces d'or (futur système)

---

## 🐛 Dépannage

### Le jeu crash lors d'un combat
→ Vérifiez votre santé (ne doit pas être très négative)

### L'inventaire est plein
→ Utilisez des potions pour faire de la place

### Vous êtes à court de potions
→ Gagnez des combats pour loot des potions

### Vous n'avez pas d'arme
→ Une arme par défaut vous est donnée, cherchez du butin

---

## 🎨 Personnalisation

### Modifier les Couleurs
Éditez `Animation/UIHelper.cs` :
```csharp
private static readonly ConsoleColor PRIMARY_COLOR = ConsoleColor.Cyan;
private static readonly ConsoleColor ACCENT_COLOR = ConsoleColor.Yellow;
private static readonly ConsoleColor SUCCESS_COLOR = ConsoleColor.Green;
private static readonly ConsoleColor ERROR_COLOR = ConsoleColor.Red;
```

### Modifier les Stats des Zombies
Éditez `Zombie.cs` dans la méthode `InitializeStats()`

### Modifier les Formules d'XP
Éditez `Xp.cs` dans la méthode `CalculateXpForNextLevel()`

---

## 📦 Contenu du Jeu

### Fichiers Importants
- `combat.cs` : Logique des combats
- `Zombie.cs` : Définition des zombies
- `health.cs` : Gestion de la santé
- `inventory.cs` : Gestion de l'inventaire
- `Xp.cs` : Système de progression
- `randomLoot.cs` : Système de butin
- `SaveManager.cs` : Sauvegarde/chargement

### Documentation
- `UI_IMPROVEMENTS.md` : Détails sur l'interface
- `UI_USAGE_GUIDE.md` : Guide d'utilisation des menus
- `COMBAT_UX_FIX.md` : Améliorations du combat

---

## 🎓 Comment Jouer - Pas à Pas

### 1. Démarrer le Jeu
```bash
dotnet run
```

### 2. Créer votre Héros
- Entrez votre nom
- Choisissez votre classe (1, 2, ou 3)

### 3. Exploration du Menu Principal
- Lisez votre description de classe
- Vérifiez votre or et XP

### 4. Premier Combat
- Sélectionnez `[1] Commencer un combat`
- Un zombie aléatoire apparaît
- Combattez jusqu'à la victoire ou la défaite

### 5. Après la Victoire
- Gagnez de l'XP
- Collectez du butin (potion/arme/or)
- Retournez au menu principal

### 6. Progression
- Montez de niveau
- Remplissez votre inventaire
- Cherchez de meilleures armes
- Sauvegardez régulièrement

---

## 🏆 Achievements (Futur)

Objectifs à atteindre :
- [ ] Atteindre le niveau 10
- [ ] Vaincre 10 Zombies Berserk
- [ ] Trouver l'arme la plus rare
- [ ] Remplir l'inventaire de potions
- [ ] Accumuler 1000 pièces d'or

---

## 📝 Changelog

### v1.0.0 (Actuel)
- ✅ Système de combat complet
- ✅ Trois classes jouables
- ✅ Quatre types de zombies
- ✅ Système d'esquive indépendant
- ✅ Système de loot aléatoire
- ✅ Sauvegarde/chargement
- ✅ Interface colorée et dynamique

---

## 👨‍💻 Développement

### Stack Technique
- **Langage** : C# (.NET 10.0)
- **Plateforme** : Console/Terminal
- **Architecture** : Programmation orientée objet

### Pour Contribuer
- Modifiez les classes de zombies
- Ajoutez de nouvelles mécaniques
- Améliorez l'interface

---

## 📞 Support

Pour toute question ou bug :
- Vérifiez les fichiers de documentation
- Consultez les fichiers source
- Testez en relançant le jeu

---

## 🎉 Merci d'avoir Joué !

Bonne chance dans votre combat contre les zombies ! 🧟

**Amusez-vous bien et que les probabilités soient avec vous !**

---

*JeuxZombie - Un jeu de survie en terminal*  
*Créé en 2026*

