namespace GamesAPI;

using System;

public class ConnectFour
{
    private const int ROWS = 6;
    private const int COLS = 7;
    private const int EMPTY = 0;
    private const int PLAYER1 = 1;
    private const int PLAYER2 = 2;
    
    private int[,] grid;
    private int[] nextRow; // Prochain emplacement libre pour chaque colonne
    private int currentPlayer;
    private bool gameOver;
    private int winner;
    private bool isTie;
    
    public ConnectFour()
    {
        InitializeGame();
    }
    
    private void InitializeGame()
    {
        grid = new int[ROWS, COLS];
        nextRow = new int[COLS];
        currentPlayer = PLAYER1;
        gameOver = false;
        winner = 0;
        isTie = false;
        
        // Initialiser la grille avec des 0
        for (int row = 0; row < ROWS; row++)
        {
            for (int col = 0; col < COLS; col++)
            {
                grid[row, col] = EMPTY;
            }
        }
        
        // Initialiser les prochaines lignes disponibles (commence par le bas)
        for (int col = 0; col < COLS; col++)
        {
            nextRow[col] = 0;
        }
    }
    
    public void PlayMove(int column)
    {
        ValidateMove(column);
        
        // Placer le jeton
        int row = nextRow[column];
        grid[row, column] = currentPlayer;
        nextRow[column]++;
        
        // Vérifier la victoire
        if (CheckWin(row, column))
        {
            gameOver = true;
            winner = currentPlayer;
            Console.WriteLine($"Joueur {currentPlayer} a gagné !");
            return;
        }
        
        // Vérifier s'il y a match nul
        if (IsBoardFull())
        {
            gameOver = true;
            isTie = true;
            Console.WriteLine("Match nul !");
            return;
        }
        
        // Changer de joueur
        currentPlayer = (currentPlayer == PLAYER1) ? PLAYER2 : PLAYER1;
    }
    
    private void ValidateMove(int column)
    {
        if (gameOver)
        {
            throw new InvalidOperationException("La partie est terminée !");
        }
        
        if (column < 0 || column >= COLS)
        {
            throw new ArgumentOutOfRangeException("Colonne hors limites !");
        }
        
        if (IsColumnFull(column))
        {
            throw new InvalidOperationException("Cette colonne est pleine !");
        }
    }
    
    private bool IsColumnFull(int column)
    {
        return nextRow[column] >= ROWS;
    }
    
    private bool IsBoardFull()
    {
        for (int col = 0; col < COLS; col++)
        {
            if (!IsColumnFull(col))
            {
                return false;
            }
        }
        return true;
    }
    
    private bool CheckWin(int row, int column)
    {
        int player = grid[row, column];
        
        // Vérifier horizontal
        if (CheckDirection(row, column, 0, 1, player) || 
            CheckDirection(row, column, 0, -1, player) ||
            CheckDirection(row, column, 0, 1, player) + CheckDirection(row, column, 0, -1, player) + 1 >= 4)
        {
            return true;
        }
        
        // Vérifier vertical
        if (CheckDirection(row, column, 1, 0, player) + CheckDirection(row, column, -1, 0, player) + 1 >= 4)
        {
            return true;
        }
        
        // Vérifier diagonale gauche (/)
        if (CheckDirection(row, column, 1, -1, player) + CheckDirection(row, column, -1, 1, player) + 1 >= 4)
        {
            return true;
        }
        
        // Vérifier diagonale droite (\)
        if (CheckDirection(row, column, 1, 1, player) + CheckDirection(row, column, -1, -1, player) + 1 >= 4)
        {
            return true;
        }
        
        return false;
    }
    
    private int CheckDirection(int row, int col, int deltaRow, int deltaCol, int player)
    {
        int count = 0;
        int r = row + deltaRow;
        int c = col + deltaCol;
        
        while (r >= 0 && r < ROWS && c >= 0 && c < COLS && grid[r, c] == player)
        {
            count++;
            r += deltaRow;
            c += deltaCol;
        }
        
        return count;
    }
    
    public void DisplayGrid()
    {
        Console.WriteLine("\n  0 1 2 3 4 5 6");
        Console.WriteLine("  -------------");
        
        for (int row = ROWS - 1; row >= 0; row--)
        {
            Console.Write($"{row}|");
            for (int col = 0; col < COLS; col++)
            {
                char symbol = grid[row, col] == EMPTY ? ' ' : 
                             grid[row, col] == PLAYER1 ? 'X' : 'O';
                Console.Write($"{symbol}|");
            }
            Console.WriteLine();
        }
        Console.WriteLine("  -------------");
    }
    
    public void PlayGame()
    {
        Console.WriteLine("=== JEU DE PUISSANCE 4 ===");
        Console.WriteLine("Joueur 1 (X) vs Joueur 2 (O)");
        Console.WriteLine("Choisissez une colonne de 0 à 6");
        
        while (!gameOver)
        {
            DisplayGrid();
            Console.WriteLine($"\nTour du joueur {currentPlayer} :");
            
            try
            {
                Console.Write("Choisissez une colonne (0-6) : ");
                string input = Console.ReadLine();
                
                if (!int.TryParse(input, out int column))
                {
                    Console.WriteLine("Veuillez entrer un nombre valide !");
                    continue;
                }
                
                PlayMove(column);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }
        
        DisplayGrid();
        
        if (isTie)
        {
            Console.WriteLine("\n🤝 Match nul ! Bien joué à tous les deux !");
        }
        else
        {
            Console.WriteLine($"\n🎉 Félicitations ! Le joueur {winner} a gagné !");
        }
    }
    
    // Méthodes utilitaires pour les tests
    public int GetCell(int row, int col)
    {
        return grid[row, col];
    }
    
    public int GetNextRow(int col)
    {
        return nextRow[col];
    }
    
    public int GetCurrentPlayer()
    {
        return currentPlayer;
    }
    
    public bool IsGameOver()
    {
        return gameOver;
    }
    
    public int GetWinner()
    {
        return winner;
    }
    
    public bool IsTieGame()
    {
        return isTie;
    }
    
    public void SetGrid(int[,] newGrid)
    {
        for (int row = 0; row < ROWS; row++)
        {
            for (int col = 0; col < COLS; col++)
            {
                grid[row, col] = newGrid[row, col];
            }
        }
        
        // Recalculer les prochaines lignes disponibles
        for (int col = 0; col < COLS; col++)
        {
            nextRow[col] = 0;
            for (int row = 0; row < ROWS; row++)
            {
                if (grid[row, col] != EMPTY)
                {
                    nextRow[col] = row + 1;
                }
            }
        }
    }
    
    public void SetGameOver(bool gameOverState, int winnerPlayer = 0)
    {
        gameOver = gameOverState;
        winner = winnerPlayer;
    }
    
    public static void Main(string[] args)
    {
        ConnectFour game = new ConnectFour();
        game.PlayGame();
        
        Console.WriteLine("\nAppuyez sur une touche pour quitter...");
        Console.ReadKey();
    }
}