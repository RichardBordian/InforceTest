namespace UrlShortener.Exceptions;

public class InvalidInputException(string message = "The input provided is invalid.") : Exception(message);