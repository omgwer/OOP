using System.Text;

namespace Lab1_4.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        string data = "Hello world!";
        byte[] byteArray = Encoding.UTF8.GetBytes(data);
        using MemoryStream inputStream = new MemoryStream(byteArray);
        using MemoryStream encryptedMem = new MemoryStream();
        using MemoryStream actualResult = new MemoryStream();

        Crypt.ConvertFileWithCondition(inputStream, encryptedMem, 42, CryptType.ENCRYPT);
        encryptedMem.Seek(0, SeekOrigin.Begin);
        Crypt.ConvertFileWithCondition(encryptedMem, actualResult, 42, CryptType.DECRYPT);
        
        Assert.That(inputStream.ToArray().SequenceEqual(actualResult.ToArray()), Is.True);
    }
}
