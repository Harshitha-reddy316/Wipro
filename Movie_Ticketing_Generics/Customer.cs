namespace movieTicketBooking_Mini.ConsoleApp.Domain;

public class Customer
{
    private static int _auto = 1;

    public int CustomerID { get; private set; }
    public string CustomerName { get; set; } = "";
    public string City { get; set; } = "";

    public Customer(string name, string city)
    {
        CustomerID = _auto++;
        CustomerName = name.Trim();
        City = city.Trim();
    }

    public Customer(int id, string name, string city)
    {
        CustomerID = id;
        CustomerName = name.Trim();
        City = city.Trim();
        if (id >= _auto) _auto = id + 1;
    }

    public string DisplayCustomerDetails() =>
        $"CustomerID: {CustomerID}\nName: {CustomerName}\nCity: {City}";
}

