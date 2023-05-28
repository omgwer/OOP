namespace Lab2_5.Exceptions;

public class UrlParseError : ArgumentException
{
    public UrlParseError() : base("Url Parse Error exception")
    {
    }

    public UrlParseError(string message) : base(message)
    {
    }
}