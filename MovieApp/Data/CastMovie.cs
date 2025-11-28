using MovieApp.Data;

public class CastMovie
{
    public int CastID { get; set; }
    public Cast Cast { get; set; } = null!;

    public int MovieID { get; set; }
    public Movie Movie { get; set; } = null!;
}
