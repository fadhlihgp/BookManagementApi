using System.Linq.Expressions;

namespace BookAuthorManagementApi.Repositories.Interfaces;

public interface IRepository<T>
{
    Task<T> Save(T entity); // Save
    T Attach(T entity);
    Task<IEnumerable<T>> SaveAll(IEnumerable<T> entities);
    
    // Find
    Task<T?> FindById(string id); // Only find by id
    Task<T?> Find(Expression<Func<T, bool>> criteria);
    T? FindNoAsync(Expression<Func<T, bool>> criteria);
    Task<T?> Find(Expression<Func<T, bool>> criteria, string[] includes);
    
    // Find All
    Task<IEnumerable<T>> FindAll();
    Task<IEnumerable<T>> FindAll(string[] includes);
    Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> criteria);
    Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> criteria, string[] includes);
    
    T Update(T entity);
    void Delete(T entity);
    void DeleteAll(IEnumerable<T> entities);
    Task<int> Count();
    Task<int> Count(Expression<Func<T, bool>> criteria);
}