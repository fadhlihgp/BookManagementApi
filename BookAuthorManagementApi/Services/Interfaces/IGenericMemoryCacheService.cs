namespace BookAuthorManagementApi.Services.Interfaces;

public interface IGenericMemoryCacheService
{
    public T GetOrCreate<T>(string key, Func<T> fetchFunction, TimeSpan? expiration = null);
    public void Remove(string key);
}