namespace GamesAPI.Exceptions;

public class InvalidAttemptsNumberException : Exception
{
    public InvalidAttemptsNumberException()
    {
    }

    public InvalidAttemptsNumberException(string message)
        : base(message)
    {
    }

    public InvalidAttemptsNumberException(string message, Exception inner)
        : base(message, inner)
    {
    }
}   