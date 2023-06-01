
class Program
{
    enum Operation
    {
        ADDICTION,      // +
        MULTIPLICATION  // *
    };
    
    public static int Main(string[] args)
    {
        string? expression = Console.ReadLine();
        if (expression == null)
        {
            throw new IOException("Error in console read");
        }

        int result = EvaluateExpression(expression);
        Console.WriteLine(result);


        

        return 0;
    }
    
    private static int EvaluateExpression(string expression)
    {
        return 0;
    }
}