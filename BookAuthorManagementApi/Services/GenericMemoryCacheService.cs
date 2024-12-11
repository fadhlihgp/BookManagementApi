using BookAuthorManagementApi.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace BookAuthorManagementApi.Services;

public class GenericMemoryCacheService : IGenericMemoryCacheService
{
    private readonly IMemoryCache _memoryCache;

    public GenericMemoryCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public T GetOrCreate<T>(string key, Func<T> fetchFunction, TimeSpan? expiration = null)
    {
        if (!_memoryCache.TryGetValue(key, out T cachedData))
        {
            cachedData = fetchFunction();

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(30)
            };

            _memoryCache.Set(key, cachedData, cacheOptions);
        }

        return cachedData;
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }
}