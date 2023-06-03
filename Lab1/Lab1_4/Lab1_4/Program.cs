using Lab1_4;

string data = "Hello, World!";
byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
using MemoryStream memoryStream = new MemoryStream(byteArray);
using StreamReader streamReader = new StreamReader(memoryStream);

char test = (char)7;

var t = StreamHandler.EncryptChar(test, 4);

    
Console.WriteLine(test);