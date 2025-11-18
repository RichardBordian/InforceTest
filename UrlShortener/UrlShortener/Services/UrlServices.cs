using UrlShortener.Interfaces.IRepos;
using UrlShortener.Interfaces.IServices;
using UrlShortener.Models;

namespace UrlShortener.Services;

public class UrlServices(IRepo<Url> urlRepo) : IUrlServices
{
    public Task<T> CreateAsync<T>(T input)
    {
        throw new NotImplementedException();
    }
}