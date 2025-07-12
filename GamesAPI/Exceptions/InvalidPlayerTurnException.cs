namespace GamesAPI.Exceptions;

public class InvelidPlayerTurnException : Exception
{
    public InvelidPlayerTurnException()
    {
    }

    public InvelidPlayerTurnException(string message)
        : base(message)
    {
    }

    public InvelidPlayerTurnException(string message, Exception inner)
        : base(message, inner)
    {
    }
}   