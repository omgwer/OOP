using System.Text;
using System.Text.RegularExpressions;
using Lab2_5.Data;
using Lab2_5.Exceptions;

namespace Lab2_5;

public class HttpUrl
{
    private static readonly string URL_REGEX = "^(?i:(http|https|ftp)?://)?([^/@: ]+)(?::([0-9]{1,5}))?([^ ]*)?";
    private static readonly string DOMAIN_REGEX = @"^([a-zA-Z0-9-]{1,63}.?)+[a-zA-Z]{2,63}$";
    //private static readonly string DOCUMENT_REGEX = @"^/?([\w-]+\/)?[\w-]+\.\w+$";
    
    private static readonly ushort
        DEFAULT_HTTP_PORT = 80,
        DEFAULT_HTTPS_PORT = 443,
        DEFAULT_FTP_PORT = 21;

    private static readonly ushort
        MIN_PORT = 1,
        MAX_PORT = 65535;

    private Protocol _protocol;
    private string _domain;
    private ushort _port;
    private string _document;

    // выполняет парсинг строкового представления URL-а, в случае ошибки парсинга
    // выбрасыват исключение CUrlParsingError, содержащее текстовое описание ошибки
    public HttpUrl(in string url)
    {
        ParseUrl(url);
    }

    //  инициализирует URL на основе переданных параметров.
    // При недопустимости входных параметров выбрасывает исключение
    // invalid_argument
    // Если имя документа не начинается с символа /, то добавляет / к имени документа
    public HttpUrl(in string domain, in string document,in Protocol protocol = Protocol.HTTP)
    {
        _protocol = protocol;
        _domain = ParseDomain(domain);
        _document = ParseDocument(document);
        _port = ParsePort(string.Empty, protocol);
    }

    // инициализирует URL на основе переданных параметров.
    // При недопустимости входных параметров выбрасывает исключение
    // invalid_argument
    // Если имя документа не начинается с символа /, то добавляет / к имени документа
    public HttpUrl(in string domain, in string document, in Protocol protocol, ushort port)
    {
        _protocol = protocol;
        _domain = ParseDomain(domain);
        _document = ParseDocument(document);
        if (port < MIN_PORT || port > MAX_PORT)
            throw new UrlParseError($"{port} - is invalid value to port!");
        _port = port;
    }

    // возвращает строковое представление URL-а. Порт, являющийся стандартным для
    // выбранного протокола (80 для http и 443 для https) в эту строку
    // не должен включаться
    public string GetUrl()
    {
        const char delemiter = '/';
        const char colon = ':';
        var stringBuilder = new StringBuilder();
        stringBuilder
            .Append(ProtocolDictionary.ProtocolToStringMap[_protocol])
            .Append(colon)
            .Append(delemiter)
            .Append(delemiter)
            .Append(_domain);
        if (!(_protocol == Protocol.HTTP && _port == DEFAULT_HTTP_PORT || _protocol == Protocol.HTTPS && _port == DEFAULT_HTTPS_PORT || _protocol == Protocol.FTP && _port == DEFAULT_FTP_PORT))
        {
            stringBuilder.Append(colon).Append(_port);
        }

        if (_document != string.Empty)
        {
            stringBuilder.Append(_document);
        }

        return stringBuilder.ToString();
    }

    // возвращает доменное имя
    public string GetDomain()
    {
        return _domain;
    }

    // Возвращает имя документа. Примеры: 
    //        /
    //        /index.html
    //        /images/photo.jpg
    public string GetDocument()
    {
        return _document;
    }

    // возвращает тип протокола
    public Protocol GetProtocol()
    {
        return _protocol;
    }

    // возвращает номер порта
    public ushort GetPort()
    {
        return _port;
    }

    private void ParseUrl(in string url)
    {
        Match match = Regex.Match(url, URL_REGEX);
        if (match.Success)
        {
            _protocol = ParseProtocol(match.Groups[1].Value);
            _domain = ParseDomain(match.Groups[2].Value);
            _port = ParsePort(match.Groups[3].Value, _protocol);
            _document = ParseDocument(match.Groups[4].Value);
        }
        else
        {
            throw new UrlParseError("Invalid url");
        }
    }

    private Protocol ParseProtocol(in string value)
    {
        var isCorrectConvert = ProtocolDictionary.StringToProtocolMap.TryGetValue(value.ToLower(), out var varProtocol);
        if (!isCorrectConvert)
            throw new UrlParseError("Cant convert string to protocol value");
        return varProtocol;
    }

    private string ParseDomain(in string value)
    {
        var match = Regex.Match(value.ToLower(), DOMAIN_REGEX);
        if (match.Success)
        {
            return match.Value;
        }

        throw new UrlParseError($"{value} - Is invalid domain name");
    }

    private ushort ParsePort(in string value, in Protocol protocol)
    {
        if (value.Length == 0)
        {
            var isCorrectConvert = ProtocolDictionary.ProtocolToPortMap.TryGetValue(protocol, out var port);
            if (!isCorrectConvert)
                throw new UrlParseError($"Error! dont have protocol to convert in dictionary!");
            return port;
        }

        ushort.TryParse(value, out var varPort);
        if (varPort >= MIN_PORT && varPort <= MAX_PORT)
            return varPort;

        throw new UrlParseError($"{value} - is invalid value for convert to port!");
    }

    private string ParseDocument(in string document)
    {
        const char delimiter = '/';
        if (document == delimiter.ToString())
            return document;
        if (document == string.Empty)
            return delimiter.ToString();
        
        // var match = Regex.Match(document, DOCUMENT_REGEX);
        // if (!match.Success)
        // {
        //     throw new UrlParseError($"{document} - Is invalid document name");  // TODO: rename - сделано
        // }
       
        if (document.First() == delimiter)
            return document;
        return delimiter + document;
    }

    public override string ToString()
    {
        const char newStringDelimiter = '\n';
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("Protocol - ").Append(ProtocolDictionary.ProtocolToStringMap[_protocol]).Append(newStringDelimiter);
        stringBuilder.Append("Domain - ").Append(_domain).Append(newStringDelimiter);
        stringBuilder.Append("Port - ").Append(_port).Append(newStringDelimiter);
        stringBuilder.Append("Data - ").Append(_document).Append(newStringDelimiter);
        return stringBuilder.ToString();
    }
}