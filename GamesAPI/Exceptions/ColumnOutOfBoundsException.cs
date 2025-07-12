namespace GamesAPI.Exceptions;

public class ColumnOutOfBoundsException : Exception
{
    public ColumnOutOfBoundsException()
    {
    }

    public ColumnOutOfBoundsException(string message)
        : base(message)
    {
    }

    public ColumnOutOfBoundsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}   