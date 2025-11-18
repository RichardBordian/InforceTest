namespace UrlShortener.Interfaces.IRepos;

public interface IRepo<T>
{
    public Task AddAsync(T entity);
    
    public Task SaveAsync();
    
    public Task<T> GetByIdAsync(int id);
    
    public Task<List<T>> GetByUserIdAsync(string userId);
}