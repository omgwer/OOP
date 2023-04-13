namespace Lab3_2.Service.Caches;

public class Cache : ICache
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