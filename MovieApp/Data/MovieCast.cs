namespace MovieApp.Data
{
    public class CastMovie
    {
        public int Id { get; set; }

        // FK → Cast (person)
        public int CastID { get; set; }
        public Cast Cast { get; set; } = null!;

        // FK → Movie
        public int MovieID { get; set; }
        public Movie Movie { get; set; } = null!;

        // movie-specific data for this cast member
        public string Role { get; set; } = string.Empty;
        public double AmountPaid { get; set; }

        // convenience property (optional)
        public string MovieTitle => Movie?.Title ?? "Unknown";
    }
}