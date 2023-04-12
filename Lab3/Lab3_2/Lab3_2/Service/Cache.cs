namespace Lab3_2.Service;

public class Cache
{
    private bool _isRun = false;

    public void Run()
    {
        _isRun = true;
    }

    public void Invalidate(SortedDictionary<string, FunctionArgument> functions)
    {
        if (!_isRun) return;
        foreach (var pair in functions)
        {
            pair.Value.cacheResult = null;
        }
    }

    public void CacheValue(FunctionArgument functionArgument, double? value)
    {
        if (!_isRun) return;
        functionArgument.cacheResult = value;
    }
}