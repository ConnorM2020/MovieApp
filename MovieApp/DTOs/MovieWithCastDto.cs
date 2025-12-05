namespace MovieApp.Dtos
{
    public class CastDto
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Role { get; set; } 
    }

    public class MovieWithCastDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public IEnumerable<CastDto> Cast { get; set; } = new List<CastDto>();
    }
}
