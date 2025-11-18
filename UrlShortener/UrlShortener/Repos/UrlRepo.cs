using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Exceptions;
using UrlShortener.Interfaces.IRepos;
using UrlShortener.Models;

namespace UrlShortener.Repos;

public class UrlRepo(ApplicationContext applicationContext) : IRepo<Url>
{
    public async Task AddAsync(Url entity)
        => await applicationContext.Urls.AddAsync(entity);

    public async Task SaveAsync()
    => await applicationContext.SaveChangesAsync();

    public async Task<Url> GetByIdAsync(int id)
        => await applicationContext.Urls.FindAsync(id) ?? throw new NotFoundException();

    public async Task<List<Url>> GetByUserIdAsync(int userId)
        => await applicationContext.Urls.Where(x => x.UserId == userId).ToListAsync();
    
    public async Task<List<Url>> GetAllAsync()
    => await applicationContext.Urls.ToListAsync();

    public async Task DeleteAsync(Url entity)
    {
        applicationContext.Urls.Remove(entity);
        await applicationContext.SaveChangesAsync();
    }
    
    public async Task<Url?> GetByFullUrlAsync(string fullUrl)
        => await applicationContext.Urls.FirstOrDefaultAsync(x => x.FullUrl == fullUrl);
}