namespace movieTicketBooking_Mini.ConsoleApp.Domain;

public class Booking
{
    private static int _auto = 1000;

    public int BookingID { get; private set; }
    public DateTime BookingDate { get; private set; }
    public int ShowID { get; set; }
    public string CustomerName { get; set; } = "";
    public int NumberOfSeats { get; set; } // 1..4
    public string SeatType { get; set; } = ""; // Platinum/Gold/Silver
    public decimal Amount { get; private set; }
    public string Email { get; set; } = "";
    public string BookingStatus { get; private set; } = "Reserved";
    public List<int> SeatNumbers { get; private set; } = new();

    public Booking(int showId, string customerName, int numberOfSeats, string seatType,
                   string email, IEnumerable<int> seatNumbers, decimal seatRate)
    {
        if (numberOfSeats < 1 || numberOfSeats > 4)
            throw new ArgumentException("Number of seats must be between 1 and 4.");

        BookingID = _auto++;
        BookingDate = DateTime.Now;
        ShowID = showId;
        CustomerName = customerName.Trim();
        NumberOfSeats = numberOfSeats;
        SeatType = seatType.Trim();
        Email = email.Trim();
        SeatNumbers = seatNumbers.ToList();
        Amount = seatRate * numberOfSeats;
        BookingStatus = "Reserved";
    }

    public Booking(int id, DateTime bookingDate, int showId, string customerName,
                   int numberOfSeats, string seatType, decimal amount, string email,
                   string bookingStatus, IEnumerable<int> seatNumbers)
    {
        BookingID = id;
        if (id >= _auto) _auto = id + 1;
        BookingDate = bookingDate;
        ShowID = showId;
        CustomerName = customerName;
        NumberOfSeats = numberOfSeats;
        SeatType = seatType;
        Amount = amount;
        Email = email;
        BookingStatus = bookingStatus;
        SeatNumbers = seatNumbers.ToList();
    }

    public string Display() =>
        $"BookingID: {BookingID} | Date: {BookingDate:g} | Show: {ShowID} | " +
        $"Customer: {CustomerName} | Seats: {NumberOfSeats} ({SeatType}) | " +
        $"SeatNos: [{string.Join(',', SeatNumbers)}] | Amount: {Amount} | Status: {BookingStatus}";
}

