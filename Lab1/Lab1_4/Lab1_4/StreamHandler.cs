namespace Lab1_4;

public class StreamHandler
{
    public static void EncryptWithKey(StreamReader inputStream, StreamWriter outputStream, byte key)
    {
    }

    public static void DecryptWithKey(StreamReader inputStream, StreamWriter outputStream, byte key)
    {
    }

    public static char EncryptChar(char ch, byte key)
    {
        var test = ch ^ key;
        var c1 = (ch >> 2) & 0b00100000;
        var c2 = (ch >> 5) & 0b00000010;
        var c3 = (ch >> 5) & 0b00000001;
        var c4 = (ch << 3) & 0b10000000;
        var c5 = (ch << 3) & 0b01000000;
        var c6 = (ch << 2) & 0b00010000;
        var c7 = (ch << 2) & 0b00001000;
        var c8 = (ch << 2) & 0b00000100;
        var encryptedChar = c1 | c2 | c3 | c4 | c5 | c6 | c7 | c8;

        return (char)encryptedChar;
    }

    public static char DecrypChar(char ch, byte key)
    {
        return ' ';
    }
}
//
// byte inputByte = 0b01111010; // Входной байт (76543210)
// byte shuffledByte = 0;
//
// // Перемешивание битов
// shuffledByte |= (byte)((inputByte & 0b00000001) << 2);  // Бит 0 -> Бит 2
// shuffledByte |= (byte)((inputByte & 0b00000100) << 2);  // Бит 2 -> Бит 4
// shuffledByte |= (byte)((inputByte & 0b00001000) >> 3);  // Бит 3 -> Бит 1
// shuffledByte |= (byte)((inputByte & 0b00010000) >> 2);  // Бит 4 -> Бит 3
// shuffledByte |= (byte)((inputByte & 0b00100000) << 3);  // Бит 5 -> Бит 7
// shuffledByte |= (byte)((inputByte & 0b10000000) >> 5);  // Бит 7 -> Бит 6
//
// Console.WriteLine($"Исходный байт:  {Convert.ToString(inputByte, 2).PadLeft(8, '0')}");
// Console.WriteLine($"Перемешанный байт: {Convert.ToString(shuffledByte, 2).PadLeft(8, '0')}");

//
//
// char EncryptChar(char ch, int key)
// {
//     ch ^= key;
//     char c1 = (ch >> 2) & 0b00100000;
//     char c2 = (ch >> 5) & 0b00000010;
//     char c3 = (ch >> 5) & 0b00000001;
//     char c4 = (ch << 3) & 0b10000000;
//     char c5 = (ch << 3) & 0b01000000;
//     char c6 = (ch << 2) & 0b00010000;
//     char c7 = (ch << 2) & 0b00001000;
//     char c8 = (ch << 2) & 0b00000100;
//     char encryptedChar = c1 | c2 | c3 | c4 | c5 | c6 | c7 | c8;
//
//     return encryptedChar;
// }
//
// char DecryptChar(char ch, int key)
// {
//     char c1 = (ch << 2) & 0b10000000;
//     char c2 = (ch << 5) & 0b01000000;
//     char c3 = (ch << 5) & 0b00100000;
//     char c4 = (ch >> 3) & 0b00010000;
//     char c5 = (ch >> 3) & 0b00001000;
//     char c6 = (ch >> 2) & 0b00000100;
//     char c7 = (ch >> 2) & 0b00000010;
//     char c8 = (ch >> 2) & 0b00000001;
//     char decryptedChar = c1 | c2 | c3 | c4 | c5 | c6 | c7 | c8;
//     decryptedChar ^= key;
//
//     return decryptedChar;
// }