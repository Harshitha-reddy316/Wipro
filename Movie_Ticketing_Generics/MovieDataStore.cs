
using movieTicketBooking_Mini.ConsoleApp.Domain;
using static movieTicketBooking_Mini.ConsoleApp.Data.Csv;

namespace movieTicketBooking_Mini.ConsoleApp.Data;

public class MovieDataStore
{
    public List<Movie> Movies { get; } = new();
    public List<Theatre> Theatres { get; } = new();
    public List<Customer> Customers { get; } = new();
    public List<LoginDetails> Logins { get; } = new();
    public List<Show> Shows { get; } = new();
    public List<Booking> Bookings { get; } = new();

    private readonly string _dir;

    public MovieDataStore(string dataDir)
    {
        _dir = dataDir;
        EnsureDir(_dir);
        // Fetch* on startup
        FetchMovies();
        FetchTheatres();
        FetchCustomers();
        FetchLogins();
        FetchShows();
        FetchBookings();

        // Ensure we have an admin
        if (!Logins.Any(l => l.LoginType == "Admin"))
            AddLogin(LoginDetails.CreateAdminDefault());
    }

    // ---------- Fetch (CSV -> memory) ----------
    public void FetchMovies()
    {
        var path = PathUnder(_dir, "Movies.csv");
        if (!File.Exists(path)) return;
        foreach (var line in File.ReadAllLines(path))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var c = Split(line);
            Movies.Add(new Movie(
                movieName: c[1], directorName: c[2], producerName: c[3],
                duration: double.Parse(c[4]), story: c[5], genre: c[6], language: c[7])
            {
                // MovieID is auto-generated same way; keep CSV value anyway
            });
        }
    }

    public void FetchTheatres()
    {
        var path = PathUnder(_dir, "Theatres.csv");
        if (!File.Exists(path)) return;
        foreach (var line in File.ReadAllLines(path))
        {
            var c = Split(line);
            Theatres.Add(new Theatre(int.Parse(c[0]), c[1], int.Parse(c[2])));
        }
    }

    public void FetchCustomers()
    {
        var path = PathUnder(_dir, "Customers.csv");
        if (!File.Exists(path)) return;
        foreach (var line in File.ReadAllLines(path))
        {
            var c = Split(line);
            Customers.Add(new Customer(int.Parse(c[0]), c[1], c[2]));
        }
    }

    public void FetchLogins()
    {
        var path = PathUnder(_dir, "Logins.csv");
        if (!File.Exists(path)) return;
        foreach (var line in File.ReadAllLines(path))
        {
            var c = Split(line);
            Logins.Add(new LoginDetails(c[0], c[1], c[2]));
        }
    }

    public void FetchShows()
    {
        var path = PathUnder(_dir, "Shows.csv");
        if (!File.Exists(path)) return;
        foreach (var line in File.ReadAllLines(path))
        {
            var c = Split(line);
            Shows.Add(new Show(
                id: int.Parse(c[0]), movieId: c[1], theatreId: int.Parse(c[2]),
                start: DateTime.Parse(c[3]), end: DateTime.Parse(c[4]),
                platinum: decimal.Parse(c[5]), gold: decimal.Parse(c[6]), silver: decimal.Parse(c[7])));
        }
    }

    public void FetchBookings()
    {
        var path = PathUnder(_dir, "Bookings.csv");
        if (!File.Exists(path)) return;
        foreach (var line in File.ReadAllLines(path))
        {
            var c = Split(line);
            var seats = c[9].Split('|', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            Bookings.Add(new Booking(
                id: int.Parse(c[0]),
                bookingDate: DateTime.Parse(c[1]),
                showId: int.Parse(c[2]),
                customerName: c[3],
                numberOfSeats: int.Parse(c[4]),
                seatType: c[5],
                amount: decimal.Parse(c[6]),
                email: c[7],
                bookingStatus: c[8],
                seatNumbers: seats));
        }
    }

    // ---------- Add (memory -> CSV) ----------
    public void AddMovie(Movie obj)
    {
        if (obj == null) throw new NullReferenceException("Movie details can’t be null");
        Movies.Add(obj);
        Append(PathUnder(_dir, "Movies.csv"),
            Line(obj.MovieID, obj.MovieName, obj.DirectorName, obj.ProducerName,
                 obj.Duration, obj.Story, obj.Genre, obj.Language));
    }

    public void AddTheatre(Theatre obj)
    {
        if (obj == null) throw new NullReferenceException("Theatre details can’t be null");
        Theatres.Add(obj);
        Append(PathUnder(_dir, "Theatres.csv"),
            Line(obj.TheatreID, obj.TheatreName, obj.NumberOfSeats));
    }

    public void AddCustomers(Customer obj)
    {
        if (obj == null) throw new NullReferenceException("Customer details can’t be null");
        Customers.Add(obj);
        Append(PathUnder(_dir, "Customers.csv"),
            Line(obj.CustomerID, obj.CustomerName, obj.City));
        // default login
        AddLogin(LoginDetails.CreateForCustomer(obj));
    }

    public void AddLogin(LoginDetails obj)
    {
        if (obj == null) throw new NullReferenceException("Login details can’t be null");
        Logins.Add(obj);
        Append(PathUnder(_dir, "Logins.csv"), Line(obj.LoginID, obj.Password, obj.LoginType));
    }

    public void AddShows(Show obj)
    {
        if (obj == null) throw new NullReferenceException("Show details can’t be null");
        Shows.Add(obj);
        Append(PathUnder(_dir, "Shows.csv"),
            Line(obj.ShowID, obj.MovieID, obj.TheatreID, obj.StartDate, obj.EndDate,
                obj.PlatinumSeatRate, obj.GoldSeatRate, obj.SilverSeatRate));
    }

    public void AddBookings(Booking obj)
    {
        if (obj == null) throw new NullReferenceException("Booking details can’t be null");
        Bookings.Add(obj);
        Append(PathUnder(_dir, "Bookings.csv"),
            Line(obj.BookingID, obj.BookingDate, obj.ShowID, obj.CustomerName,
                obj.NumberOfSeats, obj.SeatType, obj.Amount, obj.Email,
                obj.BookingStatus, string.Join('|', obj.SeatNumbers)));
    }

    // ---------- Booking helper ----------
    public Booking BookSeat(int showId, string customerName, int numberOfSeats, string seatType, string email)
    {
        var show = Shows.SingleOrDefault(s => s.ShowID == showId)
            ?? throw new InvalidOperationException("Show not found.");

        var theatre = Theatres.Single(t => t.TheatreID == show.TheatreID);

        var alreadyBooked = Bookings.Where(b => b.ShowID == showId)
                                    .SelectMany(b => b.SeatNumbers)
                                    .ToHashSet();

        // assign lowest available seat numbers
        var assigned = new List<int>();
        for (int seat = 1; seat <= theatre.NumberOfSeats && assigned.Count < numberOfSeats; seat++)
            if (!alreadyBooked.Contains(seat)) assigned.Add(seat);

        if (assigned.Count < numberOfSeats)
            throw new InvalidOperationException("Not enough seats available.");

        decimal rate = seatType.ToLower() switch
        {
            "platinum" => show.PlatinumSeatRate,
            "gold" => show.GoldSeatRate,
            "silver" => show.SilverSeatRate,
            _ => throw new ArgumentException("Seat type must be Platinum/Gold/Silver")
        };

        var booking = new Booking(showId, customerName, numberOfSeats, seatType, email, assigned, rate);
        AddBookings(booking);
        return booking;
    }

    // ---------- IO ----------
    private static void Append(string path, string line)
    {
        EnsureDir(Path.GetDirectoryName(path)!);
        using var sw = new StreamWriter(path, append: true);
        sw.WriteLine(line);
    }
}

