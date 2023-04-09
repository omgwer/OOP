using Lab3_2.Dictionary;

namespace Lab3_2;

public interface IMemory
{
    void Add(Command command);
    double? Get(Command command);
    Dictionary<string,double?> GetAllVars();
    Dictionary<string, string> GetAllFns();
}

public class Memory : IMemory
{
    private Dictionary<string, double?> _variables = new Dictionary<string, double?>();
    private Dictionary<string, string> _functions = new Dictionary<string, string>();
    
    public void Add(Command command)
    {
        throw new NotImplementedException();
    }

    public double? Get(Command command)
    {
        throw new NotImplementedException();
    }

    public Dictionary<string, double?> GetAllVars()
    {
        return _variables;
    }

    public Dictionary<string, string> GetAllFns()
    {
        return _functions;
    }
}