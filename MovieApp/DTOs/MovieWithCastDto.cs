namespace MovieApp.Dtos
{
    public class CastDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }

    public class MovieWithCastDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public IEnumerable<CastDto> Cast { get; set; } = new List<CastDto>();
    }
}
