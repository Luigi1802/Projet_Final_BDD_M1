# Projet_Final_BDD_M1

## Jeu Mastermind 

### Rappel des règles du jeu 

Le Mastermind est un jeu de réflexion dans lequel un joueur doit deviner une combinaison secrète de **4 couleurs** parmi 8 possibles. Chaque couleur ne peut apparaître qu’**une seule fois** dans la combinaison. Après chaque tentative, des indicateurs sont fournis : un indicateur **rouge** pour chaque couleur **bien placée**, et un indicateur **blanc** pour chaque **couleur correcte mais mal placée**. Le joueur dispose d’un nombre limité **d’essais** pour trouver la bonne combinaison.

### a) Analyse et justification des scénarios

Les premiers scénarios testent le lancement d'une partie. Le jeu est modélisé par une classe Mastermind, qui représente une session de jeu. Elle peut être initialisée avec deux paramètres optionnels : le nombre d'essais autorisés (par défaut 10) et la combinaison secrète (générée aléatoirement par défaut).

Ces scénarios valident donc la création d'une partie, en vérifiant que celle-ci échoue si la combinaison fournie est invalide (mauvaise longueur, doublons, ou couleur incorrecte), ou si le nombre d’essais est nul ou négatif.

On teste ensuite le mécanisme des propositions du joueur : lorsqu’un joueur soumet une combinaison, celle-ci doit être validée selon les mêmes règles. On vérifie également qu’il est impossible de jouer si la partie n’a pas commencé ou est déjà terminée.

Les scénarios suivants couvrent le déroulement complet d’une partie : gestion des essais restants, détection des conditions de victoire ou de défaite, et vérification de la précision des indicateurs rouges et blancs.

Enfin, des tests valident que la personnalisation du nombre d’essais est bien prise en compte pendant la partie.

Ainsi, les scénarios les plus critiques (initialisation de la partie et validation des combinaisons) sont traités en priorité, avant de s'intéresser au comportement détaillé du jeu et aux cas plus spécifiques.

### b) Architecture et représentation des données

Dans le fichier ```Mastermind.feature```, les combinaisons sont représentées sous forme de tableaux à une colonne contenant les quatre couleurs choisies. Cette structure rend l’écriture de scénarios accessible même à une personne non technique, en lui permettant de définir facilement ses propres combinaisons dans un format lisible et explicite.

Ce format est utilisé aussi bien pour la combinaison secrète initiale que pour les propositions successives du joueur.

Le projet est bien structuré en deux modules distincts correspondant aux deux jeux implémentés : Mastermind et ConnectFour (Puissance 4). Chaque jeu dispose de ses propres fichiers ```.feature```, de ses *step definitions* dédiées, et de ses classes métier.

### c) Stratégie BDD et bonnes pratiques

Le fichier ```.feature``` du Mastermind utilise un vocabulaire directement issu du jeu (en anglais), avec des termes comme *combination*, *guess*, *white/red indicators*, *attempts* ou encore *color*. Cela rend les scénarios immédiatement compréhensibles pour toute personne familière avec les règles du jeu.

Certaines *step definitions* ont été conçues pour être génériques et réutilisables, notamment celles liées à l’ajout d’une tentative par un joueur, afin d’éviter la duplication de code pour des cas similaires. D’autres, plus spécifiques, traitent des erreurs précises levées par la classe Mastermind lors de cas particuliers (les mauvaises combinaisons par exemple).

Cette approche facilite l’évolution du projet : les steps réutilisables s’adaptent naturellement à de nouveaux scénarios sans nécessiter de réécriture.

## Jeu puissance 4

Rappel des règles du jeu
Le Puissance 4 est un jeu de stratégie pour deux joueurs, où l’objectif est d’être le premier à aligner quatre jetons de sa couleur de manière verticale, horizontale ou diagonale sur une grille de 6 lignes et 7 colonnes. Les joueurs jouent chacun leur tour, en insérant un jeton dans l’une des colonnes : celui-ci tombe jusqu’à la position la plus basse disponible.

Un joueur ne peut pas jouer dans une colonne pleine, ni rejouer immédiatement après lui-même. La partie peut se terminer par une victoire si un alignement est formé, ou par une égalité si la grille est entièrement remplie sans vainqueur.

a) Analyse et justification des scénarios
Les premiers scénarios ont pour objectif de valider l’initialisation d’une partie de Puissance 4. Une instance du jeu est représentée par une classe ConnectFour, contenant une grille de 6 lignes par 7 colonnes. Le premier scénario vérifie que cette grille est vide lors de sa création.

On teste ensuite les premiers coups joués par les joueurs : les scénarios valident l’empilement des jetons dans une colonne, en s’assurant que ceux-ci se superposent correctement (comme attendu dans le jeu réel). L’état de la grille est vérifié après chaque coup, ainsi que la prochaine ligne disponible dans la colonne.

Des tests de robustesse suivent, pour s’assurer que le jeu gère correctement les erreurs de manipulation :

- Jouer dans une colonne déjà remplie déclenche une exception spécifique (FullColumnException).

- Jouer dans une colonne inexistante (hors limites) déclenche également une erreur (ColumnOutOfBoundsException).

- Jouer deux fois de suite par le même joueur lève une erreur d’alternance de tour (InvalidCastException).

- Tenter de jouer après la fin de la partie génère une exception (GameOverException).

La logique du jeu est également testée à travers différents scénarios de victoire :

- Une victoire verticale (4 jetons alignés dans une colonne),

- Une victoire horizontale (4 jetons sur la même ligne),
- Une victoire diagonale montante et descendante, à gauche comme à droite.

Enfin, un scénario simule une partie nulle, où la grille est entièrement remplie sans vainqueur, validant ainsi le bon fonctionnement du test d’égalité.

Ces scénarios ont été conçus pour couvrir les cas critiques du gameplay : l'empilement des jetons, la détection de la victoire, la gestion des erreurs utilisateurs et des règles du jeu. Ils permettent de s’assurer que la logique métier est correctement implémentée et que le jeu répond aux attentes en matière d'interactions utilisateur.

b) Architecture et représentation des données
Dans le fichier ConnectFour.feature, la grille est représentée sous forme de tableau structuré, chaque ligne correspondant à une ligne de la grille, et chaque colonne identifiée par une étiquette (C, O, N, N, E, C, T).

Ce format a été choisi car :

- Il rend le contenu visuellement explicite,

- Il permet à un utilisateur non technique de visualiser l’état du plateau à tout moment,

- Il simplifie l’écriture de tests complexes (victoire en diagonale par exemple) sans avoir à décrire chaque cellule individuellement.

La classe ConnectFour encapsule toute la logique métier du jeu. Elle expose des méthodes permettant de jouer un coup (PlayMove), d’accéder à une cellule (GetCell), de connaître la prochaine ligne disponible dans une colonne (GetNextRow), ou encore de récupérer le joueur gagnant (GetWinner) ou tester une égalité (IsTieGame).

c) Stratégie BDD et bonnes pratiques
Le fichier .feature de Puissance 4 respecte les bonnes pratiques BDD :

Il utilise un vocabulaire naturel et spécifique au jeu (grid, column, row, player, tie match, win),

Les étapes (steps) sont claires et réutilisables, facilitant l’ajout de nouveaux scénarios sans dupliquer la logique,

Les erreurs sont testées explicitement par type d’exception, ce qui permet un feedback précis et immédiat sur la nature d’un éventuel bug.

Certaines étapes comme Given the following grid: permettent de préconfigurer des scénarios complexes (victoires, égalités, erreurs) de manière lisible et rapide, ce qui favorise la productivité lors de la conception des tests.

L'approche adoptée est conforme à l'esprit du TDD : écrire les scénarios avant l'implémentation, valider l'échec initial, puis faire évoluer le code pour satisfaire aux exigences exprimées dans les tests.
