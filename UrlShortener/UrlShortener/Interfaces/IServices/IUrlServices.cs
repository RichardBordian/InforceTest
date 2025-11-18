namespace UrlShortener.Interfaces.IServices;

public interface IUrlServices
{
    public Task<T> CreateAsync<T>(T input);
}