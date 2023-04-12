namespace Lab3_2.Service;

public class Cache
{
    public void Invalidate(SortedDictionary<string, FunctionArgument> functions)
    {
        foreach (var pair in functions)
        {
            pair.Value.cacheResult = null;
        }
    }

    public void CacheValue(FunctionArgument functionArgument, double? value)
    {
        functionArgument.cacheResult = value;
    }
}