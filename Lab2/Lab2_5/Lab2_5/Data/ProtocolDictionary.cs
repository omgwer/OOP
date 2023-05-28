namespace Lab2_5.Data;

public static class ProtocolDictionary
{
    public static readonly Dictionary<string, Protocol> StringToProtocolMap = new()
    {
        { "http", Protocol.HTTP },
        { "https", Protocol.HTTPS },
        { "ftp", Protocol.FTP }
    };

    public static readonly Dictionary<Protocol, string> ProtocolToStringMap = new()
    {
        { Protocol.HTTP, "http" },
        { Protocol.HTTPS, "https" },
        { Protocol.FTP , "ftp"}
    };

    public static readonly Dictionary<Protocol, ushort> ProtocolToPortMap = new()
    {
        { Protocol.HTTP, 80 },
        { Protocol.HTTPS, 443 },
        { Protocol.FTP , 21}
    };
}