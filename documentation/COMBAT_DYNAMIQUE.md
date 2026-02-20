# 🎮 Système de Combat Dynamique - Documentation

## ✨ Nouvelles Fonctionnalités de Combat

### 🧟 Types de Zombies et leurs Effets Spéciaux

#### 1. 🧟 Zombie Commun
- **PV :** 100
- **Dégâts :** 12
- **XP :** 5-15
- **Effet spécial :** Aucun
- **Stratégie :** Le plus facile à vaincre

#### 2. 💢 Zombie Berserk
- **PV :** 80
- **Dégâts :** 25
- **XP :** 15-25
- **Effet spécial :** **RAGE** - Quand ses PV tombent sous 40, ses dégâts augmentent de +10
- **Stratégie :** Frappez fort et vite pour l'éliminer avant qu'il n'entre en rage !

#### 3. ☢️ Zombie Radioactif
- **PV :** 120
- **Dégâts :** 10
- **XP :** 20-30
- **Effet spécial :** **RADIATION** - Inflige 5 dégâts de radiation supplémentaires à chaque tour
- **Stratégie :** Combat rapide recommandé ! Les dégâts de radiation s'accumulent rapidement.

#### 4. 🛡️ Zombie Cuirassé
- **PV :** 200
- **Dégâts :** 15
- **XP :** 25-30
- **Effet spécial :** **ARMURE** - Réduit tous les dégâts reçus de 20%
- **Stratégie :** Combat long ! Préparez beaucoup de potions.

## 🎯 Mécaniques de Combat

### Tour du Joueur
Vous avez 4 options :
1. **Attaquer** - Inflige des dégâts avec votre arme
2. **Utiliser une potion** - Restaure des PV
3. **Voir l'inventaire** - Gère vos potions (ne consomme pas le tour)
4. **Fuir le combat** - Tentative d'échapper (aléatoire)

### Tour du Zombie
- Le zombie attaque et inflige ses dégâts de base
- **Si Radioactif :** +5 dégâts de radiation
- **Si Berserk (< 40 PV) :** Dégâts augmentés de +10

### Effets Défensifs
- **Zombie Cuirassé :** Absorbe 20% des dégâts reçus
- Affichage : `🛡️ L'armure du Zombie Cuirassé absorbe X dégâts !`

## 💡 Exemples de Combat

### Exemple 1 : Combat contre un Zombie Radioactif
```
[JOUEUR] Vous infligez 25 dégâts.
[ZOMBIE] Le Zombie Radioactif frappe ! Vous perdez 10 PV.
☢️ Le Zombie Radioactif inflige 5 dégâts de radiation à Joueur !
Total de dégâts reçus : 15 PV par tour
```

### Exemple 2 : Combat contre un Zombie Berserk
```
[JOUEUR] Vous infligez 25 dégâts.
💢 Le Zombie Berserk entre en rage ! Ses dégâts augmentent de 10 !
[ZOMBIE] Le Zombie Berserk frappe ! Vous perdez 35 PV. (25 de base + 10 de rage)
```

### Exemple 3 : Combat contre un Zombie Cuirassé
```
[JOUEUR] Vous infligez 25 dégâts.
🛡️ L'armure du Zombie Cuirassé absorbe 5 dégâts !
Dégâts réels infligés : 20 PV (25 - 5)
[ZOMBIE] Le Zombie Cuirassé frappe ! Vous perdez 15 PV.
```

## 📊 Statistiques de Combat

### Dégâts Moyens par Tour

| Type de Zombie | Dégâts de Base | Dégâts Spéciaux | Total Moyen |
|----------------|----------------|-----------------|-------------|
| Commun         | 12             | 0               | 12/tour     |
| Berserk        | 25 (35 rage)   | 0               | 25-35/tour  |
| Radioactif     | 10             | +5 radiation    | 15/tour     |
| Cuirassé       | 15             | 0               | 15/tour     |

### Durée Moyenne des Combats

| Type de Zombie | Tours Estimés | Potions Recommandées |
|----------------|---------------|----------------------|
| Commun         | 4-6 tours     | 0-1                  |
| Berserk        | 3-5 tours     | 1-2                  |
| Radioactif     | 5-7 tours     | 2-3                  |
| Cuirassé       | 8-12 tours    | 3-5                  |

## 🎓 Conseils Stratégiques

### ⚔️ Contre le Zombie Berserk
- ✅ Attaquez agressivement dès le début
- ✅ Éliminez-le avant qu'il n'atteigne 40 PV
- ✅ Si en rage, utilisez des potions pour tenir

### ☢️ Contre le Zombie Radioactif
- ✅ Minimisez le nombre de tours
- ✅ Attaquez en priorité, soignez après
- ✅ Les dégâts de radiation s'accumulent vite !

### 🛡️ Contre le Zombie Cuirassé
- ✅ Préparez-vous à un long combat
- ✅ Gardez plusieurs potions en réserve
- ✅ Utilisez vos potions moyennes/grandes

### 🧟 Contre le Zombie Commun
- ✅ Bon pour farmer de l'XP
- ✅ Parfait pour tester de nouvelles stratégies
- ✅ Économisez vos potions

## 🔧 Fonctions Implémentées

### Dans Zombie.cs

1. **ZombieRadioctifEffect(Player player)**
   - Active : À chaque tour du zombie
   - Effet : -5 PV de radiation
   - Message : `☢️ Le {Name} inflige 5 dégâts de radiation à {player.Name} !`

2. **ZombieBerserkEffect()**
   - Active : Quand PV < 40
   - Effet : +10 dégâts permanents
   - Message : `💢 Le {Name} entre en rage ! Ses dégâts augmentent de 10 !`

3. **ZombieCuirasseEffect(int incomingDamage)**
   - Active : À chaque attaque reçue
   - Effet : -20% de dégâts reçus
   - Message : `🛡️ L'armure du {Name} absorbe {reduction} dégâts !`
   - Retourne : Dégâts réduits

### Intégration dans combat.cs

- ✅ Effet Cuirassé appliqué sur TOUTES les attaques du joueur
- ✅ Effet Berserk vérifié après chaque attaque du joueur
- ✅ Effet Radioactif appliqué à chaque tour du zombie
- ✅ Messages clairs et émojis pour le feedback visuel

## 🎨 Émojis Utilisés

- 💢 Rage (Berserk)
- ☢️ Radiation (Radioactif)
- 🛡️ Armure (Cuirassé)
- ⚔️ Attaque
- 💚 Soin
- 🏃 Fuite
- ✅ Victoire
- 💀 Défaite

## 🚀 Prochaines Améliorations Possibles

- [ ] Boss zombies avec plusieurs effets
- [ ] Zombies légendaires avec stats doublées
- [ ] Système de combo d'attaques
- [ ] Compétences spéciales par classe
- [ ] Résistances élémentaires
- [ ] Système de critique (dégâts x2)

---

**Le système de combat est maintenant dynamique et stratégique ! 🎮⚔️**

