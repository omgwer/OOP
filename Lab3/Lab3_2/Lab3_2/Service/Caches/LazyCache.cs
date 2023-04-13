namespace Lab3_2.Service.Caches;

public class LazyCache : ICache
{
    public void Invalidate(SortedDictionary<string, FunctionArgument> functions)
    {
        return;
    }

    public void CacheValue(FunctionArgument functionArgument, double? value)
    {
        return;
    }
}