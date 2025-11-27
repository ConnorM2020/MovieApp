using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;

namespace MovieApp.Interfaces;

public interface IMovieService   // Abtract interface class
{
    Task<List<Movie>> GetAllMovies();
    Task<List<Movie>> GetMovieTitle();
    Task<List<Movie>> GetMovieBySearch(string Search);
    Task<List<Movie>> GetTopMovieRating();
    Task<List<Movie>> GetBottomMovieRating();
    Task<List<Movie>> GetTopFive();
    Task<List<Movie>> GetBottomFive();
    Task<Movie> GetHighestBudget();
    Task<Movie> GetLowestBudget();
    Task<Movie> GetAverageBudget();
    Task<Movie> GetHighestCastCount();

}
