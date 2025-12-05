using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Dtos;

namespace MovieApp.Interfaces;

public interface IMovieService   // Abstract interface class
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
    Task<List<Movie>> GetMoviesByGenre(MovieGenre genre);
    Task<List<Movie>> GetHighestRatedMovieByGenre();
    Task<List<MovieWithCastDto>> GetMovieCast();

    // Get all the Movies for a given Genre.
    // Get highest rated movie for each Genre

}
