using UrlShortener.DTO;

namespace UrlShortener.Interfaces.IServices;

public interface IUserServices
{
    public Task<AuthModel> CreateAsync(UserRegisterModel model);
    
    public Task<AuthModel> LoginAsync(UserLoginModel model);
}