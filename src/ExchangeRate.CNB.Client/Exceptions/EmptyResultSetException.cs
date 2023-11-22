namespace ExchangeRate.CNB.Client.Exceptions;

public class EmptyResultSetException : Exception
{
    public EmptyResultSetException()
    {
    }

    public EmptyResultSetException(string message) : base(message)
    {
    }

    public EmptyResultSetException(string message, Exception inner) : base(message, inner)
    {
    }
}