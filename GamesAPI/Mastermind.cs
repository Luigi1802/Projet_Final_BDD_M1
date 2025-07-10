using Projet_Final_BDD_M1.Steps;

namespace GamesAPI;

public class Mastermind
{
    public enum GameResult
    {
        Won = 0,
        Lost = 1,
    }
    public Mastermind()
    {
        throw new NotImplementedException();
    }
    public Mastermind(int numberOfAttempts)
    {
        throw new NotImplementedException();
    }
    public Mastermind(int numberOfAttempts, List<string> customCombination)
    {
        throw new NotImplementedException();
    }

    public int GetRemainingAttemptsNumber()
    {
        throw new NotImplementedException();
    }

    public GameResult? GetGameResult()
    {
        throw new NotImplementedException();
    }

    public List<int> AddGuess(List<string> combination)
    {
        throw new NotImplementedException();
    }
}