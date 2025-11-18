using UrlShortener.Interfaces.IRepos;
using UrlShortener.Models;

namespace UrlShortener.Repos;

public class UrlRepo : IRepo<Url>
{
    public Task AddAsync(Url entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Url> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Url>> GetByUserIdAsync(string userId)
    {
        throw new NotImplementedException();
    }
}