using System.Linq.Expressions;
using BookAuthorManagementApi.Context;
using BookAuthorManagementApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorManagementApi.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
   private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<T> Save(T entity)
    {
        var entry = await _context.Set<T>().AddAsync(entity);
        return entry.Entity;
    }

    public T Attach(T entity)
    {
        var entry = _context.Set<T>().Attach(entity);
        return entry.Entity;
    }

    public async Task<IEnumerable<T>> SaveAll(IEnumerable<T> entities)
    {
        var listEntity = entities.ToList();
        await _context.Set<T>().AddRangeAsync(listEntity);
        return listEntity;
    }

    // Find By Id
    public async Task<T?> FindById(string id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    // Find without join
    public async Task<T?> Find(Expression<Func<T, bool>> criteria)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(criteria);
    }

    public T? FindNoAsync(Expression<Func<T, bool>> criteria)
    {
        return _context.Set<T>().FirstOrDefault(criteria);
    }

    // Find With Join
    public async Task<T?> Find(Expression<Func<T, bool>> criteria, string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(criteria);
    }

    // Find ALl
    public async Task<IEnumerable<T>> FindAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    // Find all with join
    public async Task<IEnumerable<T>> FindAll(string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }

    // Find all without join with where 
    public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> criteria)
    {
        return await _context.Set<T>().Where(criteria).ToListAsync();
    }

    // find all with join and where
    public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> criteria, string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.Where(criteria).ToListAsync();
    }
    
    public T Update(T entity)
    {
        var attach = Attach(entity);
        _context.Set<T>().Update(attach);
        return attach;
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void DeleteAll(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public async Task<int> Count()
    {
        return await _context.Set<T>().CountAsync();
    }

    public async Task<int> Count(Expression<Func<T, bool>> criteria)
    {
        return await _context.Set<T>().CountAsync(criteria);
    }
}