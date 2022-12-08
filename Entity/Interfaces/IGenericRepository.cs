namespace Entity.Interfaces;

public interface IGenericRepository<T>
{
    Task<IReadOnlyList<T>> ListAllAsync();

    Task<T> GetByIdAsync(dynamic id);

    Task<T> AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);

    Task<IReadOnlyList<T>> GetPagedResponseAsync(int pageNumber, int pageSize);

    Task<int> CountAsync();
}
