namespace GamesAPI.Exceptions;

public class GameNotInProgressException : Exception
{
    public GameNotInProgressException()
    {
    }

    public GameNotInProgressException(string message)
        : base(message)
    {
    }

    public GameNotInProgressException(string message, Exception inner)
        : base(message, inner)
    {
    }
}   