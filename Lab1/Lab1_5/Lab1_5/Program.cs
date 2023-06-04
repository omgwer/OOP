
namespace  Lab1_5;

class Program
{
    public static void Main(string[] args)
    {
        TextReader test = new StringReader
        (@"     #
###
### 0 ##
#####
      
        ");

        var t = new Fill().ReadCanvasFromStream(test);
        Console.WriteLine("some");
    }
}