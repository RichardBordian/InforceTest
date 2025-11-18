namespace UrlShortener.Models;

public class Url
{
    public int Id { get; set; }
    public string FullUrl { get; set; }
    public string ShortUrl { get; set; }
    public int UserId { get; set; }
}