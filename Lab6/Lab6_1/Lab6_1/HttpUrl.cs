using Lab6_1.Data;

namespace Lab6_1;

public class HttpUrl
{
    // выполняет парсинг строкового представления URL-а, в случае ошибки парсинга
    // выбрасыват исключение CUrlParsingError, содержащее текстовое описание ошибки
    public HttpUrl(string url)
    {
        throw new NotImplementedException();
    }

    /*
        инициализирует URL на основе переданных параметров.
		При недопустимости входных параметров выбрасывает исключение
		invalid_argument
		Если имя документа не начинается с символа /, то добавляет / к имени документа
	*/
    public HttpUrl(string domain, string document, Protocol protocol = Protocol.HTTP)
    {
        throw new NotImplementedException();
    }

    /*
        инициализирует URL на основе переданных параметров.
        При недопустимости входных параметров выбрасывает исключение
        invalid_argument
        Если имя документа не начинается с символа /, то добавляет / к имени документа
    */
    public HttpUrl(string domain, string document, Protocol protocol, ushort port)
    {
        throw new NotImplementedException();
    }

    // возвращает строковое представление URL-а. Порт, являющийся стандартным для
    // выбранного протокола (80 для http и 443 для https) в эту строку
    // не должен включаться
    public string GetURL()
    {
        throw new NotImplementedException();
    }

    // возвращает доменное имя
    public string GetDomain()
    {
        throw new NotImplementedException();
    }

    /* Возвращает имя документа. Примеры: 
            /
            /index.html
            /images/photo.jpg
    */
    public string GetDocument()
    {
        throw new NotImplementedException();
    }

    // возвращает тип протокола
    public Protocol GetProtocol()
    {
        throw new NotImplementedException();
    }

    // возвращает номер порта
    public ushort GetPort()
    {
        throw new NotImplementedException();
    }
}