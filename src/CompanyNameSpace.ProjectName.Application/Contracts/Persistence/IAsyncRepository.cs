namespace CompanyNameSpace.ProjectName.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetByIntIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size);
    Task<List<T>> BulkAddAsync(List<T> entityList);
    Task<List<T>> BulkUpdateAsync(List<T> entityList);
    Task BulkDeleteAsync(List<T> entityList);
}