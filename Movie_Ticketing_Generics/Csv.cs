using System.Text;

namespace movieTicketBooking_Mini.ConsoleApp.Data;

/// <summary>
/// Very small CSV helper (no quotes/commas in fields; simple, on purpose).
/// </summary>
public static class Csv
{
    public static string Line(params object[] cols)
        => string.Join(',', cols.Select(c => (c?.ToString() ?? "").Replace(",", " ")));

    public static string[] Split(string line) => line.Split(',', StringSplitOptions.None);

    public static string PathUnder(string root, string file) => System.IO.Path.Combine(root, file);

    public static void EnsureDir(string dir)
    {
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
    }
}
