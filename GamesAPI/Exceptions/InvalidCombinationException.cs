namespace GamesAPI.Exceptions;

public class InvalidCombinationException : Exception
{
    public InvalidCombinationException()
    {
    }

    public InvalidCombinationException(string message)
        : base(message)
    {
    }

    public InvalidCombinationException(string message, Exception inner)
        : base(message, inner)
    {
    }
}   