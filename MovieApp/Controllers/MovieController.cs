using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Interfaces;

namespace MovieApp.Controllers;

// -- make sure to put Function defintion at interface as well
// Controllers expose HTTP endpoints 
[ApiController]
[Route("[controller]")]     // Call to functions made within Movie class 
public class MovieController(IMovieService movieService) : ControllerBase
{
  

    [HttpGet]   // GET /api/movies
    public async Task<ActionResult<List<Movie>>> GetAllMovies() 
        => await movieService.GetAllMovies();       // Call to Parent class 

    [HttpGet("Search")]
    public async Task<List<Movie>> GetMovieBySearch(string Search)
        => await movieService.GetMovieBySearch(Search);

    [HttpGet("Titles")]             // GET /api/movies/titles
    public async Task<ActionResult<List<Movie>>> GetMovieTitle()
        => await movieService.GetMovieTitle();      // Call to Parent class

    [HttpGet("HighestRating")]            // GET /api/movies/TopRating
    public async Task<ActionResult<List<Movie>>> GetMovieRating()
        => await movieService.GetTopMovieRating();   // Call to Parent class

    [HttpGet("TopFive")]
    public async Task<List<Movie>> GetTopFive()
        => await movieService.GetTopFive();

    [HttpGet("BottomFive")]
    public async Task<List<Movie>> GetBottomFive()
        => await movieService.GetBottomFive();

    [HttpGet("HighestBudget")]
    public async Task<Movie> GetHighestBudget()
        => await movieService.GetHighestBudget();

    [HttpGet("LowestBudget")]
    public async Task<Movie> GetLowestBudget() 
        => await movieService.GetLowestBudget();

    [HttpGet("AverageBudget")]
    public async Task<Movie> GetAverageBudget()
        => await movieService.GetAverageBudget();

    [HttpGet("HighestCastCount")]
    public async Task<Movie> GetHighestCastCount()
        => await movieService.GetHighestCastCount();


    // Get all the Movies for a given Genre.
    [HttpGet("MovieGenre")]
    public async Task<List<Movie>> GetMoviesByGenre(MovieGenre genre)
        => await movieService.GetMoviesByGenre(genre);

    // Get Highest Rated Movie by Genre
    [HttpGet("HighestGenreRating")]
    public async Task<List<Movie>> GetHighestRatedMovieByGenre()
        => await movieService.GetHighestRatedMovieByGenre();

    [HttpGet("cast")]
    public async Task<List<MovieWithCastDto>> GetMovieCast()
    {
        return await _context.Movies
            .Include(m => m.CastMovies)
                .ThenInclude(cm => cm.Cast)
            .Select(m => new MovieWithCastDto
            {
                Id = m.ID,
                Title = m.Title,
                Cast = m.CastMovies.Select(cm => new CastDto
                {
                    FirstName = cm.Cast.FirstName,
                    LastName = cm.Cast.LastName,
                    Role = cm.Cast.Role
                })
            })
            .ToListAsync();
    }

}

