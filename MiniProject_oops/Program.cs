using System;
using System.Collections.Generic;

namespace MovieTicketBooking
{
    // Movie Class
    class Movie
    {
        public string MovieID { get; private set; }
        public string MovieName;
        public string DirectorName;
        public string ProducerName;
        public double Duration;
        public string Story;
        public string Genre;
        public string Language;

        public Movie(string movieName, string directorName, string producerName,
                     double duration, string story, string genre, string language)
        {
            MovieName = movieName;
            DirectorName = directorName;
            ProducerName = producerName;
            Duration = duration;
            Story = story;
            Genre = genre;
            Language = language;

            MovieID = GenerateMovieID();
        }

        private string GenerateMovieID()
        {
            return $"{MovieName.Substring(0, 2).ToUpper()}-" +
                   $"{ProducerName.Substring(0, 2).ToUpper()}-" +
                   $"{Genre.Substring(0, 2).ToUpper()}-" +
                   $"{Language.Substring(0, 2).ToUpper()}";
        }

        public void DisplayMovieDetails()
        {
            Console.WriteLine($"Movie: {MovieName}, Genre: {Genre}, Duration: {Duration}hrs, ID: {MovieID}");
        }
    }

    // Theatre Class
    class Theatre
    {
        public int TheatreID;
        public string TheatreName;
        public int NumberOfSeats;

        public Theatre(string name, int seats)
        {
            TheatreID = new Random().Next(100, 999);  // For simplicity
            TheatreName = name;
            NumberOfSeats = seats;
        }

        public void DisplayTheatreDetails()
        {
            Console.WriteLine($"Theatre: {TheatreName}, Seats: {NumberOfSeats}, ID: {TheatreID}");
        }
    }

    // Customer Class
    class Customer
    {
        public int CustomerID;
        public string CustomerName;
        public string City;

        public Customer(string name, string city)
        {
            CustomerID = new Random().Next(1000, 9999);
            CustomerName = name;
            City = city;
        }

        public void DisplayCustomerDetails()
        {
            Console.WriteLine($"Customer: {CustomerName}, City: {City}, ID: {CustomerID}");
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Movie Ticket Booking System\n");

            // Sample Data
            Movie movie = new Movie("Avengers", "Russo", "Marvel", 2.5, "Hero Saves World", "Action", "English");
            Theatre theatre = new Theatre("Cineplex", 100);
            Customer customer = new Customer("John Doe", "New York");

            // Display Data
            Console.WriteLine("Movie Details:");
            movie.DisplayMovieDetails();
            Console.WriteLine();

            Console.WriteLine("Theatre Details:");
            theatre.DisplayTheatreDetails();
            Console.WriteLine();

            Console.WriteLine("Customer Details:");
            customer.DisplayCustomerDetails();
            Console.WriteLine();
        }
    }
}

