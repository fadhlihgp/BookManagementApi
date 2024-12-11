using Microsoft.EntityFrameworkCore;

namespace BookAuthorManagementApi.Context;

public class Persistence : IPersistence
{
    private readonly AppDbContext _context;

    public Persistence(AppDbContext context)
    {
        _context = context;
    }

    public AppDbContext Context { get; }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task<T> ExecuteTransactionAsync<T>(Func<Task<T>> action)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        var result = await strategy.ExecuteAsync(async () =>
        {
            var trans = await _context.Database.BeginTransactionAsync();
            try
            {
                var resultTrx = await action();
                await _context.SaveChangesAsync();
                await trans.CommitAsync();
                return resultTrx;
            }
            catch (Exception e)
            {
                await trans.RollbackAsync();
                throw;
            }
        });
        return result;
    }

    public T ExecuteTransaction<T>(Func<T> action)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        var result = strategy.Execute(() =>
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var result = action();
                _context.SaveChanges();
                trans.Commit();
                return result;
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw;
            }
        });

        return result;
    }
}