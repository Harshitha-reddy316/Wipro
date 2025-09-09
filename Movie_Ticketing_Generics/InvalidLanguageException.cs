namespace movieTicketBooking_Mini.ConsoleApp.Domain.Exceptions;

public class InvalidLanguageException : Exception
{
    public InvalidLanguageException()
        : base("The mentioned language is invalid. Please ensure to enter a valid language.") { }
}
