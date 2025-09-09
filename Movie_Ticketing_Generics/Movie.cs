using System;
using System.Globalization;

namespace movieTicketBooking_Mini.ConsoleApp.Domain;

public class Movie
{
    public string MovieID { get; private set; } = "";
    public string MovieName { get; set; } = "";
    public string DirectorName { get; set; } = "";
    public string ProducerName { get; set; } = "";
    public double Duration { get; set; }  // in hours
    public string Story { get; set; } = "";
    public string Genre { get; set; } = "";
    public string Language { get; set; } = "";

    public Movie(string movieName, string directorName, string producerName,
                 double duration, string story, string genre, string language)
    {
        if (duration <= 0) throw new Exceptions.InvalidDurationException();
        if (string.IsNullOrWhiteSpace(language)) throw new Exceptions.InvalidLanguageException();

        MovieName = movieName.Trim();
        DirectorName = directorName.Trim();
        ProducerName = producerName.Trim();
        Duration = duration;
        Story = story.Trim();
        Genre = genre.Trim();
        Language = language.Trim();

        MovieID = $"{Pick2(MovieName)}-{Pick2(ProducerName)}-{Pick2(Genre)}-{Pick2(Language)}";
    }

    private static string Pick2(string s)
    {
        s = (s ?? string.Empty).Trim();
        if (s.Length >= 2) return s[..2].ToUpperInvariant();
        return s.ToUpperInvariant().PadRight(2, 'X');
    }

    public string DisplayMovieDetails() =>
        $"MovieID: {MovieID}\nName: {MovieName}\nDirector: {DirectorName}\nProducer: {ProducerName}\n" +
        $"Duration: {Duration} hrs\nStory: {Story}\nGenre: {Genre}\nLanguage: {Language}";
}
