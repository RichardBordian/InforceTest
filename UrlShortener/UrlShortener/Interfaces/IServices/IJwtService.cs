namespace UrlShortener.Interfaces.IServices;

public interface IJwtService
{
    public string GenerateToken(int id, string password);
}