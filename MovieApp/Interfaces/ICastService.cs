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

        Task<List<Cast>> GetHighestPaidCast(int movieId);
        Task<List<Cast>> GetOldestMovieCast(int movieID);
        Task<List<Cast>> GetMostCastAppearances();
        Task<List<Cast>> GetLowestBudget();

        Task<List<Cast>> GetAverageAgeRange();

    }
}
