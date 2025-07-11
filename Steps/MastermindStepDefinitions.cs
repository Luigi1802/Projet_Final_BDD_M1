using FluentAssertions;
using GamesAPI;
using GamesAPI.Exceptions;

namespace Projet_Final_BDD_M1.Steps;

[Binding]
public sealed class MastermindStepDefinitions
{
    private List<String> _customCombination = new List<String>();
    private List<String> _playerCombination = new List<String>();
    private List<int> _redAndWhiteIndicators = new List<int>();
    private Mastermind _mastermindGame;
    private int _attempsLeft;
    private Nullable<Mastermind.GameResult> _gameResult;
    private Exception _exception;

    [Given(@"the game starts with default parameters")]
    public void GivenTheGameStartsWithDefaultParameters()
    {
        try
        {
            _mastermindGame = new Mastermind();
        }
        catch (Exception e)
        {
            _exception = e;
        }
    }
    
    [Given(@"the game starts with custom combination:")]
    public void GivenTheGameStartsWithCustomCombination(Table table)
    {
        foreach (var row in table.Rows)
        {
            var color = row["Colors"];
            _customCombination.Add(color);
        }
        try
        {
            _mastermindGame = new Mastermind(10, _customCombination);
        }
        catch (Exception e)
        {
            _exception = e;
        }
    }
    
    [Given(@"the game starts with (.*) attempts")]
    public void GivenTheGameStartsWithAttempts(int p0)
    {
        try
        {
            _mastermindGame = new Mastermind(p0);
        }
        catch (Exception e)
        {
            _exception = e;
        }
    }
    
    [Given(@"the game starts with (.*) attempts and custom combination:")]
    public void GivenTheGameStartsWithAttemptsAndCustomCombination(int p0, Table table)
    {
        foreach (var row in table.Rows)
        {
            var color = row["Colors"];
            _customCombination.Add(color);
        }
        try
        {
            _mastermindGame = new Mastermind(p0, _customCombination);
        }
        catch (Exception e)
        {
            _exception = e;
        }
    }

    [Then(@"the game is started correctly")]
    public void ThenTheGameIsStartedCorrectly()
    {
        _attempsLeft = _mastermindGame.GetRemainingAttemptsNumber();
        _attempsLeft.Should().BeGreaterThan(0);
    }

    [Then(@"the number of attempts left is (.*)")]
    public void ThenTheNumberOfAttempsLeftIs(int p0)
    {
        _attempsLeft = _mastermindGame.GetRemainingAttemptsNumber();
        _attempsLeft.Should().Be(p0);
    }

    [Then(@"the game ends on a victory")]
    public void ThenTheGameEndsOnAVictory()
    {
        _attempsLeft = _mastermindGame.GetRemainingAttemptsNumber();
        _gameResult = _mastermindGame.GetGameResult();
        _attempsLeft.Should().Be(0);
        _gameResult.Should().Be(Mastermind.GameResult.Won);
    }

    [Then(@"the game is lost")]
    public void ThenTheGameIsLost()
    {
        _attempsLeft = _mastermindGame.GetRemainingAttemptsNumber();
        _gameResult = _mastermindGame.GetGameResult();
        _attempsLeft.Should().Be(0);
        _gameResult.Should().Be(Mastermind.GameResult.Lost);
    }

    [Given(@"the player adds the guess:")]
    public void GivenThePlayerAddsTheGuess(Table table)
    {
        foreach (var row in table.Rows)
        {
            var color = row["Colors"];
            _playerCombination.Add(color);
        }
        try
        {
            _redAndWhiteIndicators = _mastermindGame.AddGuess(_playerCombination);
        }
        catch (Exception e)
        {
            _exception = e;
        }
    }

    [Given(@"the player adds (.*) wrong guesses for combination:")]
    public void GivenThePlayerAddsWrongGuessesForCombination(int p0, Table table)
    {
        List<String> falseCombination = new List<String>();
        var falsified = false;
        const String falseColor = "Red";
        foreach (var row in table.Rows)
        {
            var color = row["Colors"];
            if (!falsified && color != falseColor) {
                falseCombination.Add(falseColor);
                falsified = true;
            } else {
                falseCombination.Add(color);
            }
        }
        for (var i = 0; i < p0; i++)
        {
            try
            {
                _mastermindGame.AddGuess(falseCombination);
            }
            catch (Exception e)
            {
                _exception = e;
            }
        }
    }

    [Then(@"the number of red indicators is (.*)")]
    public void ThenTheNumberOfRedIndicatorsIs(int p0)
    {
        _redAndWhiteIndicators[0].Should().Be(p0);
    }

    [Then(@"the number of white indicators is (.*)")]
    public void ThenTheNumberOfWhiteIndicatorsIs(int p0)
    {
        _redAndWhiteIndicators[1].Should().Be(p0);
    }

    [Then(@"the invalid attempts number error is thrown")]
    public void ThenTheInvalidAttemptsNumberErrorIsThrown()
    {
        _exception.Should().NotBeNull("No exception was thrown.");
        _exception.Should().BeOfType<InvalidAttemptsNumberException>("The exception was thrown but isn't InvalidAttemptsNumberException.");
    }

    [Then(@"the invalid combination error is thrown")]
    public void ThenTheInvalidCombinationErrorIsThrown()
    {
        _exception.Should().NotBeNull("No exception was thrown.");
        _exception.Should().BeOfType<InvalidCombinationException>("The exception was thrown but isn't InvalidCombinationException.");
    }

    [Then(@"the game not in progress error is thrown")]
    public void ThenTheGameNotInProgressErrorIsThrown()
    {
        _exception.Should().NotBeNull("No exception was thrown.");
        _exception.Should().BeOfType<GameNotInProgressException>("The exception was thrown but isn't GameNotInProgressException.");
    }
}