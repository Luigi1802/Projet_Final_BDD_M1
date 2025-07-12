namespace GamesAPI.Exceptions;

public class FullColumnException : Exception
{
    public FullColumnException()
    {
    }

    public FullColumnException(string message)
        : base(message)
    {
    }

    public FullColumnException(string message, Exception inner)
        : base(message, inner)
    {
    }
}   