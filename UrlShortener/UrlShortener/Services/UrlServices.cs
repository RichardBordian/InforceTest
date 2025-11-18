using UrlShortener.DTO;
using UrlShortener.Interfaces.IRepos;
using UrlShortener.Interfaces.IServices;
using UrlShortener.Models;

namespace UrlShortener.Services;

public class UrlServices(IRepo<Url> urlRepo) : IUrlServices
{
    private const string Base62Chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    public async Task CreateAsync (UrlCreateModel urlCreateModel)
    {
        if (await UrlExistsAsync(urlCreateModel.Url))
        {
            throw new Exceptions.InvalidInputException("URL already exists");
        }
        
        var url = new Url
        {
            FullUrl = urlCreateModel.Url,
            UserId = urlCreateModel.User.Id,
            CreatedDate = DateTime.UtcNow
        };
        await urlRepo.AddAsync(url);
        await urlRepo.SaveAsync();

        url.ShortUrl = EncodeToBase62(url.Id);
        await urlRepo.SaveAsync();
    }

    public async Task<Url> GetByShortCode(string shortCode)
    {
        var id = DecodeFromBase62(shortCode);
        return await urlRepo.GetByIdAsync(id);
    }

    public async Task<Url> GetByIdAsync(int id)
    {
        return await urlRepo.GetByIdAsync(id);
    }

    public async Task<List<Url>> GetAllUrlsAsync()
    {
        return await urlRepo.GetAllAsync();
    }

    public async Task<List<Url>> GetUserUrlsAsync(int userId)
    {
        return await urlRepo.GetByUserIdAsync(userId);
    }

    public async Task DeleteAsync(int urlId, int userId, bool isAdmin)
    {
        var url = await urlRepo.GetByIdAsync(urlId);
        
        if (!isAdmin && url.UserId != userId)
        {
            throw new UnauthorizedAccessException("You can only delete your own URLs");
        }
        
        await urlRepo.DeleteAsync(url);
    }

    public async Task<bool> UrlExistsAsync(string fullUrl)
    {
        if (urlRepo is Repos.UrlRepo urlRepoImpl)
        {
            var existing = await urlRepoImpl.GetByFullUrlAsync(fullUrl);
            return existing != null;
        }
        return false;
    }

    
    private static string EncodeToBase62(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number), "Number must be greater than 0");

        var result = new System.Text.StringBuilder();
        while (number > 0)
        {
            result.Insert(0, Base62Chars[number % Base62Chars.Length]);
            number /= Base62Chars.Length;
        }
        
        return result.ToString();
    }

    private static int DecodeFromBase62(string base62String)
    {
        int result = 0;
        for (int i = 0; i < base62String.Length; i++)
        {
            int charIndex = Base62Chars.IndexOf(base62String[i]);
            if(charIndex == -1)
                throw new ArgumentException($"Invalid Base62 character: {base62String[i]}");

            result = result * 62 + charIndex;
        }
        return result;
    }
}