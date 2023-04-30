namespace Lab6_1.Exceptions;

public class UrlParseError : ArgumentException
{
    public UrlParseError() : base("Argument exception")
    {
    }

    public UrlParseError(string message) : base(message)
    {
    }
}