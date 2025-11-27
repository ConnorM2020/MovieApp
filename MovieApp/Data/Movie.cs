namespace MovieApp.Data;

public class Movie  // Movie object with multiple attributes
{
    public int ID { get; set; }
    public string Title { get; set; } = string.Empty;       
    public string Description { get; set; } = string.Empty;        
    public int Rating { get; set; }        
    public double Budget { get; set; }   
    public int NumberOfCast { get; set; }

    // one movie, many cast links
    public ICollection<CastMovie> CastMovies { get; set; } = new List<CastMovie>();
    public MovieGenre Genre { get; set; }
       // can be used within MovieSeeData
}
