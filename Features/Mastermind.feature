Feature: Mastermind

# Lancement de partie classique 
Scenario: Start game with default parameters
	Given the game starts with default parameters
	Then the game is started correctly
	And the number of attemps left is 10

# Lancement de partie avec une combinaison personnalisée valide 
Scenario: Start game with valid custom combination
	Given the game starts with valid custom combination
	Then the game is started correctly
	And the number of attemps left is 10
	
# Lancement de partie avec un 1 essai
Scenario: Start game with more than 0 attempts
	Given the game starts with valid custom combination and 1 attempts
	Then the game is started correctly
	And the number of attemps left is 1
	
# Lancement de partie avec un 0 essai (invalide)
Scenario: Start game with 0 attempts
	Given the game starts with valid custom combination and 0 attempts
	Then the invalid attempts number error is thrown
	
# Lancement de partie avec un -1 essai (invalide)
Scenario: Start game with less than 0 attempts
	Given the game starts with valid custom combination and -1 attempts
	Then the invalid attempts number error is thrown
	
# Lancement de partie avec une combinaison personnalisée invalide (longueur incorrecte)
Scenario: Start game with invalid custom combination (length)	
	Given the game starts with invalid length combination
	Then the invalid combination error is thrown

# Lancement de partie avec une combinaison personnalisée invalide (couleur en double)
Scenario: Start game with invalid custom combination (duplicate color)	
	Given the game starts with duplicate colors combination
	Then the invalid combination error is thrown

# Lancement de partie avec une combinaison personnalisée invalide (couleur invalide)
Scenario: Start game with invalid custom combination (invalid color)	
	Given the game starts with an invalid color in combination
	Then the invalid combination error is thrown

# Lancement d'une partie puis essai invalide (longueur incorrecte)
Scenario: Start game and add invalid guess (length)	
	Given the game starts with default parameters
	Then the game is started correctly
	Given the player adds a guess with 3 colors
	Then the invalid combination error is thrown
	
# Lancement d'une partie puis essai invalide (couleur en double)
Scenario: Start game and add invalid guess (duplicate color)
	Given the game starts with default parameters
	Then the game is started correctly
	Given the player adds a guess with 2 duplicate colors
	Then the invalid combination error is thrown
	
# Lancement d'une partie puis essai invalide (couleur invalide)
Scenario: Start game and add invalid guess (invalid color)
	Given the game starts with default parameters
	Then the game is started correctly
	Given the player adds a guess with an invalid color
	Then the invalid combination error is thrown

# Lancement d'une partie et victoire au premier essai
Scenario: Start game and find custom combination on first attempts
	Given the game starts with valid custom combination
	Then the game is started correctly
	Given the player adds a correct guess
	Then the game ends on a victory
	
# Lancement d'une partie et victoire au troisième essai
Scenario: Start game and find custom combination on third attempts
	Given the game starts with valid custom combination
	Then the game is started correctly
	Given the player adds a guess with 1 right placed color and 1 wrong placed color
	Then the number of red indicators is 1
	And the number of white indicators is 1
	And the game has not ended
	Given the player adds a guess with 2 right placed color and 2 wrong placed color
	Then the number of red indicators is 2
	And the number of white indicators is 2
	And the game has not ended
	Given the player adds a correct guess
	Then the game ends on a victory

# Lancement d'une partie et défaite après 10 essais
Scenario: Start game with default 10 attempts and lose
	Given the game starts with valid custom combination
	Then the game is started correctly
	And the number of attemps left is 10
	Given the player adds a guess with 0 right placed color and 0 wrong placed color
	Then the number of red indicators is 0
	And the number of white indicators is 0
	And the game has not ended
	Given the player adds a guess with 1 right placed color and 0 wrong placed color
	Then the number of red indicators is 1
	And the number of white indicators is 0
	And the game has not ended
	Given the player adds a guess with 1 right placed color and 1 wrong placed color
	Then the number of red indicators is 1
	And the number of white indicators is 1
	And the game has not ended
	Given the player adds a guess with 2 right placed color and 0 wrong placed color
	Then the number of red indicators is 2
	And the number of white indicators is 0
	And the game has not ended
	Given the player adds a guess with 2 right placed color and 1 wrong placed color
	Then the number of red indicators is 2
	And the number of white indicators is 1
	And the game has not ended
	Given the player adds a guess with 3 right placed color and 0 wrong placed color
	Then the number of red indicators is 3
	And the number of white indicators is 0
	Given the player adds a guess with 0 right placed color and 1 wrong placed color
	Then the number of red indicators is 0
	And the number of white indicators is 1
	And the game has not ended
	Given the player adds a guess with 0 right placed color and 2 wrong placed color
	Then the number of red indicators is 0
	And the number of white indicators is 2
	And the game has not ended
	Given the player adds a guess with 0 right placed color and 3 wrong placed color
	Then the number of red indicators is 0
	And the number of white indicators is 3
	And the game has not ended
	Given the player adds a guess with 0 right placed color and 4 wrong placed color
	Then the number of red indicators is 0
	And the number of white indicators is 4
	And the game is lost
	
# Lancement d'une partie et défaite après 8 essais
Scenario: Start game with 8 attempts and lose
	Given the game starts with valid custom combination and 8 attempts
	Then the game is started correctly
	And the number of attemps left is 8
	Given the player adds 8 wrong guesses
	Then the game is lost
		
# Lancement d'une partie et défaite après 12 essais
Scenario: Start game with 12 attempts and lose
	Given the game starts with valid custom combination and 12 attempts
	Then the game is started correctly
	And the number of attemps left is 12
	Given the player adds 10 wrong guesses
	Then the game has not ended
	Given the player adds a guess with 0 right placed color and 0 wrong placed color
	Then the number of red indicators is 0
	And the number of white indicators is 0
	And the game has not ended
	Given the player adds a guess with 0 right placed color and 0 wrong placed color
	Then the number of red indicators is 0
	And the number of white indicators is 0
	And the game is lost

# Lancement d'une partie et victoire après 11 essais
Scenario: Start game with 12 attempts and win on 11th attempts
	Given the game starts with valid custom combination and 12 attempts
	Then the game is started correctly
	And the number of attemps left is 12
	Given the player adds 10 wrong guesses
	Then the game has not ended
	Given the player adds a correct guess
	Then the game ends on a victory