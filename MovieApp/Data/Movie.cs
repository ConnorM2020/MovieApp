namespace MovieApp.Data;

public class Movie  // Movie object with multiple attributes
{
    public int ID { get; set; }
    public string Title { get; set; } = string.Empty;       
    public string Description { get; set; } = string.Empty;        
    public int Rating { get; set; }        
    public decimal Budget { get; set; }   
    public int NumberOfCast { get; set; }
    public MovieGenre genre { get; internal set; }

    // one movie, many cast links
    // one person, many movie links - CastMovie acts like SQL composite table
    public ICollection<CastMovie> CastMovies { get; set; } = new List<CastMovie>();

    // can be used within MovieSeeData
}
