using Lab6_1.Data;
using Lab6_1.Exceptions;

namespace Lab6_1.Tests;

public class HttpUrlTests
{
    [TestCase("http://google.com", Protocol.HTTP, "google.com", (ushort)80, "/", "http://google.com/")]
    [TestCase("https://google.com/", Protocol.HTTPS, "google.com", (ushort)443, "/", "https://google.com/")]
    [TestCase("https://google.com:800", Protocol.HTTPS, "google.com", (ushort)800, "/", "https://google.com:800/")]
    [TestCase("https://hello-world.com:800/file.jpg", Protocol.HTTPS, "hello-world.com", (ushort)800, "/file.jpg",
        "https://hello-world.com:800/file.jpg")]
    [TestCase("https://hello-world.com:800/someone/file.jpg", Protocol.HTTPS, "hello-world.com", (ushort)800,
        "/someone/file.jpg", "https://hello-world.com:800/someone/file.jpg")]
    public void HttpUrl_Constructor_ParseUrl(string url, Protocol expectedProtocol, string expectedDomain,
        ushort expectedPort, string expectedDocument, string expectedUrl)
    {
        // Act
        var result = new HttpUrl(url);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetProtocol(), Is.EqualTo(expectedProtocol));
            Assert.That(result.GetDomain(), Is.EqualTo(expectedDomain));
            Assert.That(result.GetPort(), Is.EqualTo(expectedPort));
            Assert.That(result.GetDocument(), Is.EqualTo(expectedDocument));
            Assert.That(result.GetUrl(), Is.EqualTo(expectedUrl));
        });
    }

    [TestCase(Protocol.HTTP, "google.com", "/", "http://google.com/", "/", (ushort)80)]
    [TestCase(Protocol.HTTPS, "google.com", "/", "https://google.com/", "/", (ushort)443)]
    [TestCase(Protocol.HTTPS, "google.com", "", "https://google.com/", "/", (ushort)443)]
    [TestCase(Protocol.HTTPS, "help-me.com", "test.pdf", "https://help-me.com/test.pdf", "/test.pdf", (ushort)443)]
    [TestCase(Protocol.HTTPS, "help-me.com", "some-one/test.pdf", "https://help-me.com/some-one/test.pdf",
        "/some-one/test.pdf", (ushort)443)]
    [TestCase(Protocol.HTTP, "help-me.com", "/some-one/test.pdf", "http://help-me.com/some-one/test.pdf",
        "/some-one/test.pdf", (ushort)80)]
    public void HttpUrl_SecondConstructor(Protocol protocol, string domain, string document, string expectedUrl,
        string expectedDocument, ushort expectedPort)
    {
        var result = new HttpUrl(domain, document, protocol);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetProtocol(), Is.EqualTo(protocol));
            Assert.That(result.GetDomain(), Is.EqualTo(domain));
            Assert.That(result.GetPort(), Is.EqualTo(expectedPort));
            Assert.That(result.GetDocument(), Is.EqualTo(expectedDocument));
            Assert.That(result.GetUrl(), Is.EqualTo(expectedUrl));
        });
    }

    [TestCase(Protocol.HTTP, "google.com", "/", (ushort)80, "http://google.com/", "/", (ushort)80)]
    [TestCase(Protocol.HTTPS, "google.com", "/", (ushort)443, "https://google.com/", "/", (ushort)443)]
    [TestCase(Protocol.HTTPS, "google.com", "", (ushort)1, "https://google.com:1/", "/", (ushort)1)]
    [TestCase(Protocol.HTTPS, "help-me.com", "test.pdf", (ushort)80, "https://help-me.com:80/test.pdf", "/test.pdf", (ushort)80)]
    [TestCase(Protocol.HTTPS, "help-me.com", "some-one/test.pdf", (ushort)80,
        "https://help-me.com:80/some-one/test.pdf", "/some-one/test.pdf", (ushort)80)]
    [TestCase(Protocol.HTTP, "help-me.com", "/some-one/test.pdf", (ushort)443,
        "http://help-me.com:443/some-one/test.pdf", "/some-one/test.pdf", (ushort)443)]
    [TestCase(Protocol.HTTP, "help-me.com", "/some-one/test.pdf", (ushort)65535,
        "http://help-me.com:65535/some-one/test.pdf", "/some-one/test.pdf", (ushort)65535)]
    public void HttpUrl_ThirdConstructor(Protocol protocol, string domain, string document, ushort port,
        string expectedUrl, string expectedDocument, ushort expectedPort)
    {
        //public HttpUrl(string domain, string document, Protocol protocol, ushort port)
        var result = new HttpUrl(domain, document, protocol, port);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetProtocol(), Is.EqualTo(protocol));
            Assert.That(result.GetDomain(), Is.EqualTo(domain));
            Assert.That(result.GetDocument(), Is.EqualTo(expectedDocument));
            Assert.That(result.GetUrl(), Is.EqualTo(expectedUrl));
        });
    }

    [TestCase("ftp://google.com")]
    [TestCase("http:google.com")]
    [TestCase("http:/google.com")]
    [TestCase("http//google.com")]
    [TestCase("http://google")]
    [TestCase("http://google.")]
    [TestCase("http://google.с")]
    [TestCase("http://.com")]
    [TestCase("http!://gg.com")]
    [TestCase("http!:/!/google.com")]
    [TestCase("http!:/!/google.com")]
    [TestCase("http://google.com:0")]
    [TestCase("http://google.com:65536")]
    [TestCase("http://google.com:1337/file")]
    [TestCase("http://google.com:1337/file.")]
    [TestCase("http://google.com:1337//file.")]
    [TestCase("http://google.com:1337/file.hpg/file.gfg")]
    [TestCase("http://google.com:1337/some/file./")]
    public void Negative_HttpUrl_FirstConstructor(string url)
    {
        Assert.Throws<UrlParseError>( () => new HttpUrl(url));
    }
    
    [TestCase(Protocol.HTTP, "http://google.com", "/")]
    [TestCase(Protocol.HTTP, "google.", "")]
    [TestCase(Protocol.HTTP, "google.cm", "/someone")]
    [TestCase(Protocol.HTTP, "google.cm", "someone")]
    public void Negative_HttpUrl_SecondConstructor( Protocol protocol, string domain, string document)
    {
        Assert.Throws<UrlParseError>( () => new HttpUrl(domain, document, protocol));
    }
    
    [TestCase(Protocol.HTTP, "http://google.com", "/",(ushort)65535)]
    [TestCase(Protocol.HTTP, "google.", "",(ushort)65535)]
    [TestCase(Protocol.HTTP, "google.cm", "/someone", (ushort)65535)]
    [TestCase(Protocol.HTTP, "google.cm", "someone", (ushort)65535)]
    [TestCase(Protocol.HTTP, "google.cm", "/someone", (ushort)65534)]
    [TestCase(Protocol.HTTP, "google.cm", "/someone.file", (ushort)0)]
    public void Negative_HttpUrl_ThirdConstructor( Protocol protocol, string domain, string document, ushort port)
    {
        Assert.Throws<UrlParseError>( () => new HttpUrl(domain, document, protocol, port));
    }
}