using Lab6_1.Data;

namespace Lab6_1.Tests;

public class Tests
{
    [Test]
    public void HttpUrl_Constructor_WithUrlString_CreatesUrlObject()
    {
        // Arrange
        var urlString = "http://www.example.com/path/to/document.html";

        // Act
        var url = new HttpUrl(urlString);

        // Assert
        Assert.AreEqual(Protocol.HTTP, url.GetProtocol());
        Assert.AreEqual("www.example.com", url.GetDomain());
        Assert.AreEqual("/path/to/document.html", url.GetDocument());
        Assert.AreEqual(80, url.GetPort());
    }

    [Test]
    public void HttpUrl_Constructor_WithDomainAndDocumentAndProtocol_CreatesUrlObject()
    {
        // Arrange
        var domain = "www.example.com";
        var document = "/path/to/document.html";
        var protocol = Protocol.HTTPS;

        // Act
        var url = new HttpUrl(domain, document, protocol);

        // Assert
        Assert.AreEqual(protocol, url.GetProtocol());
        Assert.AreEqual(domain, url.GetDomain());
        Assert.AreEqual(document, url.GetDocument());
        Assert.AreEqual(443, url.GetPort());
    }

    [Test]
    public void HttpUrl_Constructor_WithDomainAndDocumentAndProtocolAndPort_CreatesUrlObject()
    {
        // Arrange
        var domain = "www.example.com";
        var document = "/path/to/document.html";
        var protocol = Protocol.HTTP;
        var port = (ushort)8080;

        // Act
        var url = new HttpUrl(domain, document, protocol, port);

        // Assert
        Assert.AreEqual(protocol, url.GetProtocol());
        Assert.AreEqual(domain, url.GetDomain());
        Assert.AreEqual(document, url.GetDocument());
        Assert.AreEqual(port, url.GetPort());
    }
}