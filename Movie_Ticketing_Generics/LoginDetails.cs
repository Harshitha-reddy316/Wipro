
namespace movieTicketBooking_Mini.ConsoleApp.Domain;

public class LoginDetails
{
    public string LoginID { get; set; } = "";
    public string Password { get; set; } = "";
    public string LoginType { get; set; } = ""; // "Admin" | "Customer"

    public LoginDetails(string loginId, string password, string loginType)
    {
        LoginID = loginId;
        Password = password;
        LoginType = loginType;
    }

    public static LoginDetails CreateAdminDefault()
        => new("MOVIEADMIN", "MOVIEADMIN", "Admin");

    public static LoginDetails CreateForCustomer(Customer c)
        => new(c.CustomerID.ToString(), c.CustomerID.ToString(), "Customer");
}

