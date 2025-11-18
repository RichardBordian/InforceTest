using UrlShortener.DTO;
using UrlShortener.Models;

namespace UrlShortener.Interfaces.IServices;

public interface IUrlServices
{
    public Task CreateAsync (UrlCreateModel input);

    public Task<Url> GetByShortCode(string shortCode);
    
    public Task<Url> GetByIdAsync(int id);
    
    public Task<List<Url>> GetAllUrlsAsync ();
    
    public Task<List<Url>> GetUserUrlsAsync(int userId);
    
    public Task DeleteAsync(int urlId, int userId, bool isAdmin);
    
    public Task<bool> UrlExistsAsync(string fullUrl);
}