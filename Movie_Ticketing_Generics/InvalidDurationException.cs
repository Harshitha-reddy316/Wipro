namespace movieTicketBooking_Mini.ConsoleApp.Domain.Exceptions;

public class InvalidDurationException : Exception
{
    public InvalidDurationException()
        : base("The mentioned movie duration is invalid. Please ensure to enter a valid duration.") { }
}
