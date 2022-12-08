using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly NetworkContext _context;

    public GenericRepository(NetworkContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(dynamic id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
    {
        return await _context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Set<T>().CountAsync();
    }
}
