using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Interfaces;
using MovieApp.Dtos;

namespace MovieApp.Controllers;

// -- make sure to put Function definition at interface as well
// Controllers expose HTTP endpoints 
[ApiController]
[Route("[controller]")]     // Call to functions made within Movie class 
public class MovieController(IMovieService movieService) : ControllerBase
{
    [HttpGet]   // GET /api/movies
    public async Task<List<Movie>> GetAllMovies() => await movieService.GetAllMovies();
    // Call to Parent class 

    [HttpGet("Search")]
    public async Task<List<Movie>> GetMovieBySearch(string Search)  => await movieService.GetMovieBySearch(Search);

    [HttpGet("GetMovieCast")]
    public async Task<List<MovieWithCastDto>> GetMovieCast() => await movieService.GetMovieCast();

    [HttpGet("Titles")]             // GET /api/movies/titles
    public async Task<ActionResult<List<Movie>>> GetMovieTitle() => await movieService.GetMovieTitle();
    
    [HttpGet("HighestRating")]            // GET /api/movies/TopRating
    public async Task<ActionResult<List<Movie>>> GetMovieRating() => await movieService.GetTopMovieRating();
                                                                        // Call to Parent class
    [HttpGet("TopFive")]
    public async Task<List<Movie>> GetTopFive() => await movieService.GetTopFive();

    [HttpGet("BottomFive")]
    public async Task<List<Movie>> GetBottomFive() => await movieService.GetBottomFive();

    [HttpGet("HighestBudget")]
    public async Task<Movie> GetHighestBudget() => await movieService.GetHighestBudget();

    [HttpGet("LowestBudget")]
    public async Task<Movie> GetLowestBudget() => await movieService.GetLowestBudget();

    [HttpGet("AverageBudget")]
    public async Task<Movie> GetAverageBudget() => await movieService.GetAverageBudget();

    [HttpGet("HighestCastCount")]
    public async Task<Movie> GetHighestCastCount() => await movieService.GetHighestCastCount();

    // Get all the Movies for a given Genre.
    [HttpGet("MovieGenre")]
    public async Task<List<Movie>> GetMoviesByGenre(MovieGenre genre) => await movieService.GetMoviesByGenre(genre);

    // Get Highest Rated Movie by Genre
    [HttpGet("HighestGenreRating")]
    public async Task<List<Movie>> GetHighestRatedMovieByGenre() => await movieService.GetHighestRatedMovieByGenre();
}

