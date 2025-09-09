using movieTicketBooking_Mini.ConsoleApp.Data;
using movieTicketBooking_Mini.ConsoleApp.Domain;

namespace movieTicketBooking_Mini.ConsoleApp;

class Program
{
    static void Main()
    {
        var dataDir = Path.Combine(AppContext.BaseDirectory, "DataFiles");
        var store = new MovieDataStore(dataDir);

        while (true)
        {
            Console.WriteLine("\n==== Movie Ticket Booking (Console) ====");
            Console.WriteLine("1) Add Movie");
            Console.WriteLine("2) Add Theatre");
            Console.WriteLine("3) Add Customer");
            Console.WriteLine("4) Add Show");
            Console.WriteLine("5) Book Seats");
            Console.WriteLine("6) List Movies");
            Console.WriteLine("7) List Shows");
            Console.WriteLine("8) List Bookings");
            Console.WriteLine("0) Exit");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        AddMovie(store); break;
                    case "2":
                        AddTheatre(store); break;
                    case "3":
                        AddCustomer(store); break;
                    case "4":
                        AddShow(store); break;
                    case "5":
                        BookSeats(store); break;
                    case "6":
                        foreach (var m in store.Movies) Console.WriteLine(m.DisplayMovieDetails() + "\n");
                        break;
                    case "7":
                        foreach (var s in store.Shows) Console.WriteLine(s.DisplayShowDetails());
                        break;
                    case "8":
                        foreach (var b in store.Bookings) Console.WriteLine(b.Display());
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void AddMovie(MovieDataStore store)
    {
        Console.Write("Movie Name: ");
        var name = Console.ReadLine()!;
        Console.Write("Director: ");
        var dir = Console.ReadLine()!;
        Console.Write("Producer: ");
        var prod = Console.ReadLine()!;
        Console.Write("Duration (hours): ");
        var duration = double.Parse(Console.ReadLine()!);
        Console.Write("Story: ");
        var story = Console.ReadLine()!;
        Console.Write("Genre: ");
        var genre = Console.ReadLine()!;
        Console.Write("Language: ");
        var lang = Console.ReadLine()!;

        var movie = new Movie(name, dir, prod, duration, story, genre, lang);
        store.AddMovie(movie);
        Console.WriteLine("Added:\n" + movie.DisplayMovieDetails());
    }

    static void AddTheatre(MovieDataStore store)
    {
        Console.Write("Theatre Name: ");
        var name = Console.ReadLine()!;
        Console.Write("Number of seats: ");
        var seats = int.Parse(Console.ReadLine()!);
        var t = new Theatre(name, seats);
        store.AddTheatre(t);
        Console.WriteLine("Added:\n" + t.DisplayTheatreDetails());
    }

    static void AddCustomer(MovieDataStore store)
    {
        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!;
        Console.Write("City: ");
        var city = Console.ReadLine()!;
        var c = new Customer(name, city);
        store.AddCustomers(c);
        Console.WriteLine("Added:\n" + c.DisplayCustomerDetails());
        Console.WriteLine($"Login created: ID={c.CustomerID}, Password={c.CustomerID}");
    }

    static void AddShow(MovieDataStore store)
    {
        Console.Write("MovieID (ex: AB-MN-CO-EN): ");
        var movieId = Console.ReadLine()!;
        Console.Write("TheatreID: ");
        var theatreId = int.Parse(Console.ReadLine()!);
        Console.Write("Start (yyyy-MM-dd HH:mm): ");
        var start = DateTime.Parse(Console.ReadLine()!);
        Console.Write("End   (yyyy-MM-dd HH:mm): ");
        var end = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Platinum rate: ");
        var p = decimal.Parse(Console.ReadLine()!);
        Console.Write("Gold rate: ");
        var g = decimal.Parse(Console.ReadLine()!);
        Console.Write("Silver rate: ");
        var s = decimal.Parse(Console.ReadLine()!);

        var show = new Show(movieId, theatreId, start, end, p, g, s);
        store.AddShows(show);
        Console.WriteLine("Added:\n" + show.DisplayShowDetails());
    }

    static void BookSeats(MovieDataStore store)
    {
        Console.Write("ShowID: ");
        var showId = int.Parse(Console.ReadLine()!);
        Console.Write("Customer Name: ");
        var cust = Console.ReadLine()!;
        Console.Write("SeatType (Platinum/Gold/Silver): ");
        var type = Console.ReadLine()!;
        Console.Write("No. of seats (1..4): ");
        var count = int.Parse(Console.ReadLine()!);
        Console.Write("Email: ");
        var email = Console.ReadLine()!;

        var booking = store.BookSeat(showId, cust, count, type, email);
        Console.WriteLine("Booked:\n" + booking.Display());
    }
}
