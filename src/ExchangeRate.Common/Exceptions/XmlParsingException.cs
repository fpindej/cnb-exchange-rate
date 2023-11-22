namespace ExchangeRate.Common.Exceptions;

public class XmlParsingException : Exception
{
    public XmlParsingException()
    {
    }

    public XmlParsingException(string message) : base(message)
    {
    }

    public XmlParsingException(string message, Exception inner) : base(message, inner)
    {
    }
}