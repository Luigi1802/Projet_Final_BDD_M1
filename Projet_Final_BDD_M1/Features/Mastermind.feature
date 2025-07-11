Feature: Mastermind

# Lancement de partie classique 
Scenario: Start game with default parameters
	Given the game starts with default parameters
	Then the game is started correctly
	And the number of attempts left is 10

# Lancement de partie avec une combinaison personnalisée valide 
Scenario: Start game with valid custom combination
	Given the game starts with custom combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	Then the game is started correctly
	And the number of attempts left is 10
	
# Lancement de partie avec un 1 essai
Scenario: Start game with more than 0 attempts
	Given the game starts with 1 attempts
	Then the game is started correctly
	And the number of attempts left is 1
	
# Lancement de partie avec un 0 essai (invalide)
Scenario: Start game with 0 attempts
	Given the game starts with 0 attempts
	Then the invalid attempts number error is thrown
	
# Lancement de partie avec un -1 essai (invalide)
Scenario: Start game with less than 0 attempts
	Given the game starts with -1 attempts
	Then the invalid attempts number error is thrown
	
# Lancement de partie avec une combinaison personnalisée invalide (longueur incorrecte)
Scenario: Start game with invalid custom combination (length)	
	Given the game starts with custom combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	  | Yellow | 
	Then the invalid combination error is thrown

# Lancement de partie avec une combinaison personnalisée invalide (couleur en double)
Scenario: Start game with invalid custom combination (duplicate color)	
	Given the game starts with custom combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | White  | 
	  | White  | 
	Then the invalid combination error is thrown

# Lancement de partie avec une combinaison personnalisée invalide (couleur invalide)
Scenario: Start game with invalid custom combination (invalid color)	
	Given the game starts with custom combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | White  | 
	  | Indigo | 
	Then the invalid combination error is thrown

# Lancement d'une partie puis essai invalide (longueur incorrecte)
Scenario: Start game and add invalid guess (length)	
	Given the game starts with default parameters
	Then the game is started correctly
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Red    | 
	  | Blue   | 
	Then the invalid combination error is thrown
	
# Lancement d'une partie puis essai invalide (couleur en double)
Scenario: Start game and add invalid guess (duplicate color)
	Given the game starts with default parameters
	Then the game is started correctly
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Red    | 
	  | Blue   | 
	  | White  | 
	Then the invalid combination error is thrown
	
# Lancement d'une partie puis essai invalide (couleur invalide)
Scenario: Start game and add invalid guess (invalid color)
	Given the game starts with default parameters
	Then the game is started correctly
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | Black  | 
	Then the invalid combination error is thrown

# Lancement d'une partie et victoire au premier essai
Scenario: Start game and find custom combination on first attempt
	Given the game starts with custom combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	Then the game is started correctly
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  |  
	Then the game ends on a victory
	
# Tentative d'essai sans lancer de partie
Scenario: Adding a guess without starting a game
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	Then the game not in progress error is thrown
	
# Tentative d'essai après avoir terminé la partie
Scenario: Start and win game then add another attempt
	Given the game starts with custom combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	Then the game is started correctly
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	Then the game ends on a victory
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	Then the game not in progress error is thrown
	
# Lancement d'une partie et victoire au troisième essai
Scenario: Start game and find custom combination on third attempts
	Given the game starts with custom combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	Then the game is started correctly
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Pink   | 
	  | White  | 
	  | Orange | 
	Then the number of red indicators is 1
	And the number of white indicators is 1
	And the number of attempts left is 9
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | White  | 
	  | Blue   | 
	  | Green  | 
	Then the number of red indicators is 2
	And the number of white indicators is 2
	And the number of attempts left is 8
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	Then the game ends on a victory

# Lancement d'une partie et défaite après 10 essais
Scenario: Start game with default 10 attempts and lose
	Given the game starts with custom combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	Then the game is started correctly
	And the number of attempts left is 10
	Given the player adds the guess:
	  | Colors | 
	  | Pink   |
	  | Purple | 
	  | Orange | 
	  | Yellow | 
	Then the number of red indicators is 0
	And the number of white indicators is 0
	And the number of attempts left is 9
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Purple | 
	  | Orange | 
	  | Yellow | 
	Then the number of red indicators is 1
	And the number of white indicators is 0
	And the number of attempts left is 8
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | White  | 
	  | Orange | 
	  | Yellow | 
	Then the number of red indicators is 1
	And the number of white indicators is 1
	And the number of attempts left is 7
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Orange | 
	  | Yellow | 
	Then the number of red indicators is 2
	And the number of white indicators is 0
	And the number of attempts left is 6
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | White  | 
	  | Yellow | 
	Then the number of red indicators is 2
	And the number of white indicators is 1
	And the number of attempts left is 5
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Purple | 
	  | White  | 
	Then the number of red indicators is 3
	And the number of white indicators is 0
	And the number of attempts left is 4
	Given the player adds the guess:
	  | Colors | 
	  | White  |
	  | Purple | 
	  | Orange | 
	  | Yellow | 
	Then the number of red indicators is 0
	And the number of white indicators is 1
	And the number of attempts left is 3
	Given the player adds the guess:
	  | Colors | 
	  | White  |
	  | Red    | 
	  | Orange | 
	  | Yellow | 
	Then the number of red indicators is 0
	And the number of white indicators is 2
	And the number of attempts left is 2
	Given the player adds the guess:
	  | Colors | 
	  | White  |
	  | Red    | 
	  | Green  | 
	  | Yellow | 
	Then the number of red indicators is 0
	And the number of white indicators is 3
	And the number of attempts left is 1
	Given the player adds the guess:
	  | Colors | 
	  | White  |
	  | Red    | 
	  | Green  | 
	  | Blue   | 
	Then the number of red indicators is 0
	And the number of white indicators is 4
	And the game is lost
	
# Lancement d'une partie et défaite après 8 essais
Scenario: Start game with 8 attempts and lose
	Given the game starts with 8 attempts and custom combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	Then the game is started correctly
	And the number of attempts left is 8
	Given the player adds 8 wrong guesses for combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  |
	Then the game is lost
		
# Lancement d'une partie et défaite après 12 essais
Scenario: Start game with 12 attempts and lose
	Given the game starts with 12 attempts and custom combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	Then the game is started correctly
	And the number of attempts left is 12
	Given the player adds 10 wrong guesses for combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  |
	Then the number of attempts left is 2
	Given the player adds the guess:
	  | Colors | 
	  | Pink   |
	  | Purple | 
	  | Orange | 
	  | Yellow | 
	Then the number of red indicators is 0
	And the number of white indicators is 0
	And the number of attempts left is 1
	Given the player adds the guess:
	  | Colors | 
	  | Blue   |
	  | Green  | 
	  | White  | 
	  | Yellow | 
	Then the number of red indicators is 1
	And the number of white indicators is 2
	And the game is lost

# Lancement d'une partie et victoire après 11 essais
Scenario: Start game with 12 attempts and win on 11th attempts
	Given the game starts with 12 attempts and custom combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	Then the game is started correctly
	And the number of attempts left is 12
	Given the player adds 10 wrong guesses for combination:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  |
	Then the number of attempts left is 2
	Given the player adds the guess:
	  | Colors | 
	  | Red    |
	  | Green  | 
	  | Blue   | 
	  | White  | 
	Then the game ends on a victory