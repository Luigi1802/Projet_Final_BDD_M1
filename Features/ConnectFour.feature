Feature: ConnectFour

# Lancement d'une partie
@mytag
Scenario: Start of the game
	Given a new connect four grid
	Then the grid should be empty

# Premier coup du joueur rouge (couleur 1)
Scenario: First move played
	Given a new connect four grid
	When player 1 plays column 0
	Then the grid column 0 row 0 should be 1
	And columns 1 to 6 should be empty
	And next row for column 0 should be 1

# Jouer sur un jeton	
Scenario: Stack a token
	Given the following grid:
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
    When player 2 plays column 0
    Then the grid column 0 row 1 should be 2
    And column 0 row 0 should be 1
    And next row for column 0 should be 2
	
# Jouer sur une colonne pleine
Scenario: Play a full column
	Given the following grid:
	  | 2 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 2 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 2 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
    When player 1 plays column 0
	Then the full column error is thrown

# Jouer une colonne hors cadre
Scenario: Play column out of bounds
	When player 1 plays column 7
	Then the column out of bounds error is thrown
	
# Jouer une ligne hors cadre
Scenario: Play row out of bounds
	When player 1 plays row 6
	Then a row out of bounds error is thrown
	
# Victoire verticale
Scenario: Vertical win
	Given the following grid:
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 1 | 2 | 0 | 0 | 0 | 0 | 0 |
	  | 1 | 2 | 0 | 0 | 0 | 0 | 0 |
	  | 1 | 2 | 0 | 0 | 0 | 0 | 0 |
	When player 1 plays column 0
	Then player 1 should win
	
# Victoire horizontale
Scenario: Horizontal win
	Given the following grid:
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 2 | 2 | 2 | 0 | 0 | 0 | 0 |
	  | 1 | 1 | 1 | 0 | 0 | 0 | 0 |
	When player 1 plays column 3
	Then player 1 should win
	
# Victoire diagonale gauche
Scenario: Left diagonal win
	Given the following grid:
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 1 | 1 | 0 | 0 | 0 |
	  | 0 | 1 | 1 | 2 | 0 | 0 | 0 |
	  | 1 | 2 | 2 | 2 | 2 | 0 | 0 |
	When player 1 plays column 3
	Then player 1 should win
	
# Victoire diagonale droite
Scenario: Right diagonal win
	Given the following grid:
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
	  | 1 | 1 | 0 | 0 | 0 | 0 | 0 |
	  | 2 | 1 | 1 | 0 | 0 | 0 | 0 |
	  | 2 | 2 | 2 | 1 | 2 | 0 | 0 |
	When player 1 plays column 0
	Then player 1 should win
	
# Partie nulle
Scenario: Tie match
	Given the following grid:
	  | 2 | 1 | 2 | 2 | 2 | 1 | 0 |
	  | 1 | 2 | 1 | 2 | 1 | 2 | 1 |
	  | 2 | 1 | 2 | 1 | 2 | 2 | 2 |
	  | 1 | 1 | 1 | 2 | 1 | 1 | 1 |
	  | 2 | 1 | 1 | 2 | 1 | 2 | 1 |
	  | 2 | 2 | 2 | 1 | 2 | 1 | 1 |
	When player 2 plays column 6
	Then a tie match should be declared

# Respecter l'alternance des joueurs	
Scenario: Player alternation
	Given a new connect four grid
	When player 1 plays column 0
	And player 1 plays column 0
	Then the wrong turn error is thrown
	
# Jouer après la fin d'une partie
Scenario: Play after game is won
	Given player 1 has won the game
	When player 2 tries to play column 0
	Then the game over error is thrown