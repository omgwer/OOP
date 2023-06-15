using System.ComponentModel;

namespace Lab1_4;

public static class CryptService
{
    public static byte[] ConvertBytesWithCondition(byte[] buffer, int length, byte key, CryptType cryptType)
    {
        Func<byte, byte, byte> cryptFunc = cryptType switch
        {
            CryptType.ENCRYPT => EncryptByte,
            CryptType.DECRYPT => DecryptByte,
            _ => throw new InvalidEnumArgumentException("CryptType not found!")
        };
        var bytes = new byte[length];

        for (var i = 0; i < length; i++)
            bytes[i] = cryptFunc(buffer[i], key);

        return bytes;
    }

    private static byte EncryptByte(byte bt, byte key)
    {
        bt = (byte)(bt ^ key);
        var bt1 = (bt >> 2) & 0b00100000;
        var bt2 = (bt >> 5) & 0b00000010;
        var bt3 = (bt >> 5) & 0b00000001;
        var bt4 = (bt << 3) & 0b10000000;
        var bt5 = (bt << 3) & 0b01000000;
        var bt6 = (bt << 2) & 0b00010000;
        var bt7 = (bt << 2) & 0b00001000;
        var bt8 = (bt << 2) & 0b00000100;
        var encryptedChar = (byte)(bt1 | bt2 | bt3 | bt4 | bt5 | bt6 | bt7 | bt8);
        return encryptedChar;
    }

    private static byte DecryptByte(byte bt, byte key)
    {
        var bt1 = (bt << 2) & 0b10000000;
        var bt2 = (bt << 5) & 0b01000000;
        var bt3 = (bt << 5) & 0b00100000;
        var bt4 = (bt >> 3) & 0b00010000;
        var bt5 = (bt >> 3) & 0b00001000;
        var bt6 = (bt >> 2) & 0b00000100;
        var bt7 = (bt >> 2) & 0b00000010;
        var bt8 = (bt >> 2) & 0b00000001;
        var encryptedChar = (byte)(bt1 | bt2 | bt3 | bt4 | bt5 | bt6 | bt7 | bt8);
        return (byte)(encryptedChar ^ key);
    }
}