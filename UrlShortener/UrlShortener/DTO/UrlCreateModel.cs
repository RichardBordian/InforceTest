using UrlShortener.Models;

namespace UrlShortener.DTO;

public class UrlCreateModel
{
    public string Url { get; set; }
    public User User { get; set; }
}