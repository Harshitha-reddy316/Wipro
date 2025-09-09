namespace movieTicketBooking_Mini.ConsoleApp.Domain;

public class Show
{
    private static int _auto = 1;

    public int ShowID { get; private set; }
    public string MovieID { get; set; } = "";
    public int TheatreID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal PlatinumSeatRate { get; set; }
    public decimal GoldSeatRate { get; set; }
    public decimal SilverSeatRate { get; set; }

    public Show(string movieId, int theatreId, DateTime start, DateTime end,
                decimal platinum, decimal gold, decimal silver)
    {
        ShowID = _auto++;
        MovieID = movieId;
        TheatreID = theatreId;
        StartDate = start;
        EndDate = end;
        PlatinumSeatRate = platinum;
        GoldSeatRate = gold;
        SilverSeatRate = silver;
    }

    public Show(int id, string movieId, int theatreId, DateTime start, DateTime end,
                decimal platinum, decimal gold, decimal silver)
        : this(movieId, theatreId, start, end, platinum, gold, silver)
    {
        ShowID = id;
        if (id >= _auto) _auto = id + 1;
    }

    public string DisplayShowDetails() =>
        $"ShowID: {ShowID} | Movie: {MovieID} | Theatre: {TheatreID} | " +
        $"From: {StartDate:g} To: {EndDate:g} | Rates (P/G/S): {PlatinumSeatRate}/{GoldSeatRate}/{SilverSeatRate}";
}
