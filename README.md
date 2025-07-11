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