namespace BookAuthorManagementApi.Context;

public interface IPersistence
{
    public AppDbContext Context { get; }
    Task SaveChangesAsync();
    void SaveChanges();
    Task<T> ExecuteTransactionAsync<T>(Func<Task<T>> action);
    T ExecuteTransaction<T>(Func<T> action);
}