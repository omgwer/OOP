using System.ComponentModel;

namespace Lab1_4;

public static class Crypt
{
    public static void EncryptAndSave(string inputFileName, string outputFileName, byte key)
    {
        using var inputStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);
        using var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write);
        ConvertFileWithCondition(inputStream, outputStream, key, CryptType.ENCRYPT);
    }

    public static void DecryptAndSave(string inputFileName, string outputFileName, byte key)
    {
        using var inputStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);
        using var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write);
        ConvertFileWithCondition(inputStream, outputStream, key, CryptType.DECRYPT);
    }

    public static void ConvertFileWithCondition(Stream inputStream, Stream outputStream, byte key,
        CryptType cryptType)
    {
        var buffer = new byte[4096];
        int bytesRead;
        while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            var decryptedByte = CryptService.ConvertBytesWithCondition(buffer, bytesRead, key, cryptType);
            outputStream.Write(decryptedByte);
        }
    }
}