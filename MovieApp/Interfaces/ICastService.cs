using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;

namespace MovieApp.Interfaces
{
    public interface ICastService 
    {
        Task<List<Cast>> GetAllCast();  
        Task<List<Cast>> GetMovieCast(int movieId);   // Movie = m.NumberOfCast
                                                    // Task<List<Cast>> GetMovieCast(int movieID);    // return list of cast
        Task<List<string>> GetFullNamesByMovie(int movieId);

    }
}
