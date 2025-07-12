using GamesAPI;
using GamesAPI.Exceptions;
using NUnit.Framework;

namespace Projet_Final_BDD_M1.Steps;

[Binding]
public sealed class ConnectFourStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    private ConnectFour _game;
    private Exception _lastException;

    public ConnectFourStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }


    [Given(@"a new connect four grid")]
    public void GivenANewConnectFourGrid()
    {
        _game = new ConnectFour();
        _scenarioContext["game"] = _game;
    }

    [Then(@"the grid should be empty")]
    public void ThenTheGridShouldBeEmpty()
    {
        var game = (ConnectFour)_scenarioContext["game"];
        
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                Assert.AreEqual(0, game.GetCell(row, col));
            }
        }
    }

    [When(@"player (.*) plays column (.*)")]
    public void WhenPlayerPlaysColumn(int player, int column)
    {
        var game = (ConnectFour)_scenarioContext["game"];
    
        try
        {
            // Pour le test d'alternance, on vérifie si c'est le bon joueur
            // Si ce n'est pas le cas, on lève une exception
            if (game.GetCurrentPlayer() != player)
            {
                throw new InvalidCastException("Wrong player to play !");
            }
        
            game.PlayMove(column);
            _lastException = null;
        }
        catch (Exception ex)
        {
            _lastException = ex;
        }
    }
    
    [Then(@"column (.*) row (.*) should be (.*)")]
    public void ThenColumnRowShouldBe(int column, int row, int value)
    {
        var game = (ConnectFour)_scenarioContext["game"];
        Assert.AreEqual(value, game.GetCell(row, column));
    }

    [Then(@"columns (.*) to (.*) should be empty")]
    public void ThenColumnsToShouldBeEmpty(int startColumn, int endColumn)
    {
        var game = (ConnectFour)_scenarioContext["game"];
        
        for (int col = startColumn; col <= endColumn; col++)
        {
            for (int row = 0; row < 6; row++)
            {
                Assert.AreEqual(0, game.GetCell(row, col));
            }
        }
    }

    [Then(@"next row for column (.*) should be (.*)")]
    public void ThenNextRowForColumnShouldBe(int column, int value)
    {
        var game = (ConnectFour)_scenarioContext["game"];
        Assert.AreEqual(value, game.GetNextRow(column));
    }

    [Given(@"the following grid:")]
    public void GivenTheFollowingGrid(Table table)
    {
        if (_game == null)
        {
            _game = new ConnectFour();
            _scenarioContext["game"] = _game;
        }

        var game = (ConnectFour)_scenarioContext["game"];

        // Créer une grille 2D à partir du tableau
        int[,] grid = new int[6, 7];

        // Les lignes du tableau sont dans l'ordre inverse (de haut en bas)
        for (int tableRow = 0; tableRow < 6; tableRow++)
        {
            int gridRow = 5 - tableRow; // Inverser l'ordre des lignes
        
            var row = table.Rows[tableRow];
            for (int col = 0; col < 7; col++)
            {
                string cellValue = row[col];
                grid[gridRow, col] = int.Parse(cellValue);
            }
        }

        game.SetGrid(grid);
    }

    [Then(@"player (.*) should win")]
    public void ThenPlayerShouldWin(int winner)
    {
        var game = (ConnectFour)_scenarioContext["game"];
    
        Assert.AreEqual(winner, game.GetWinner(), $"Player {winner} should have won");
    }

    [Then(@"a tie match should be declared")]
    public void ThenATieMatchShouldBeDeclared()
    {
        var game = (ConnectFour)_scenarioContext["game"];
    
        Assert.IsTrue(game.IsTieGame(), "Tie match should be declared");
    }
    
    [Given(@"player (.*) has won the game")]
    public void GivenPlayerHasWonTheGame(int winner)
    {
        _game = new ConnectFour();
        _scenarioContext["game"] = _game;
    
        // Créer une configuration où le joueur a gagné
        int[,] winningGrid = new int[6, 7];
        for (int col = 0; col < 4; col++)
        {
            winningGrid[0, col] = winner;
        }
    
        _game.SetGrid(winningGrid);
        _game.SetGameOver(true, winner);
    }

    [Then(@"the full column error is thrown")]
    public void ThenTheFullColumnErrorIsThrown()
    {
        Assert.IsNotNull(_lastException);
        Assert.IsInstanceOf<FullColumnException>(_lastException);
    }

    [Then(@"the column out of bounds error is thrown")]
    public void ThenTheColumnOutOfBoundsErrorIsThrown()
    {
        Assert.IsNotNull(_lastException);
        Assert.IsInstanceOf<ColumnOutOfBoundsException>(_lastException);
    }

    [Then(@"the wrong turn error is thrown")]
    public void ThenTheWrongTurnErrorIsThrown()
    {
        Assert.IsNotNull(_lastException);
        Assert.IsInstanceOf<InvalidCastException>(_lastException);
    }

    [Then(@"the game over error is thrown")]
    public void ThenTheGameOverErrorIsThrown()
    {
        Assert.IsNotNull(_lastException);
        Assert.IsInstanceOf<GameOverException>(_lastException);
    }
}