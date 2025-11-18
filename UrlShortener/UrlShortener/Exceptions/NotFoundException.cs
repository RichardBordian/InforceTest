namespace UrlShortener.Exceptions;

public class NotFoundException(string message = "Not found exception") : Exception(message);