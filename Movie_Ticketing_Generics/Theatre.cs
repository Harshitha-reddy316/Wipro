namespace movieTicketBooking_Mini.ConsoleApp.Domain;

public class Theatre
{
    private static int _auto = 1;

    public int TheatreID { get; private set; }
    public string TheatreName { get; set; } = "";
    public int NumberOfSeats { get; set; }

    public Theatre(string theatreName, int numberOfSeats)
    {
        TheatreID = _auto++;
        TheatreName = theatreName.Trim();
        NumberOfSeats = numberOfSeats;
    }

    // For CSV hydration
    public Theatre(int id, string theatreName, int numberOfSeats)
    {
        TheatreID = id;
        TheatreName = theatreName.Trim();
        NumberOfSeats = numberOfSeats;
        if (id >= _auto) _auto = id + 1;
    }

    public string DisplayTheatreDetails() =>
        $"TheatreID: {TheatreID}\nTheatre: {TheatreName}\nSeats: {NumberOfSeats}";
}
