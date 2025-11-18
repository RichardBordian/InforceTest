using Microsoft.AspNetCore.Identity;
using UrlShortener.DTO;
using UrlShortener.Exceptions;
using UrlShortener.Interfaces.IServices;
using UrlShortener.Models;

namespace UrlShortener.Services;

public class UserServices(UserManager<User> userManager, IJwtService jwtService) : IUserServices
{
    public async Task<AuthModel> CreateAsync(UserRegisterModel model)
    {
        var user = new User
        {
            UserName = model.Username
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            throw new InvalidInputException();
        }

        return new AuthModel
        {
            AccessToken = jwtService.GenerateToken(user.Id, user.UserName)
        };
    }

    public async Task<AuthModel> LoginAsync(UserLoginModel model)
    {
        var user = await userManager.FindByNameAsync(model.Email);

        if (user is null)
        {
            throw new InvalidInputException();
        }

        var passwordIsValid = await userManager.CheckPasswordAsync(user, model.Password);

        if (!passwordIsValid)
        {
            throw new InvalidInputException();
        }

        return new AuthModel()
        {
            AccessToken = jwtService.GenerateToken(user.Id, user.UserName)
        };
    }
}