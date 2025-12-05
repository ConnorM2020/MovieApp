using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Dtos;
using MovieApp.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MovieApp.Services;
// SQL commands to reach to DB
public class MovieService(MovieContext dbContext) : IMovieService
{
    // Implementation of interface IMovieService
    public async Task<List<Movie>> GetAllMovies() => await dbContext.Movies.ToListAsync();
    // Get a Movie by title 
    public async Task<List<Movie>> GetMovieTitle() => await dbContext.Movies.OrderBy(movie => movie.Title).ToListAsync();
    // Get Movies by ratings
    public async Task<List<Movie>> GetTopMovieRating() => await dbContext.Movies.OrderByDescending(movie => movie.Rating).ToListAsync();
    public async Task<List<Movie>> GetBottomMovieRating() => await dbContext.Movies.OrderBy(movie => movie.Rating).ToListAsync();   // Ascending - start from bottom

    // Get Movies that contain a title string.  SQL WHERE m.Title = search
    public async Task<List<Movie>> GetMovieBySearch(string search) => await dbContext.Movies.Where(m => m.Title.Contains(search)).ToListAsync();

    // Get Movie ID, Title with corresponding cast f.name, s.name + Role
    public async Task<List<MovieWithCastDto>> GetMovieCast()
    {
        return await dbContext.Movies
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

    // get top 5 and lowest 5
    public async Task<List<Movie>> GetTopFive() => await dbContext.Movies.OrderByDescending(m => m.Rating).Take(5).ToListAsync();
    public async Task<List<Movie>> GetBottomFive() => await dbContext.Movies.OrderBy(m => m.Rating).Take(5).ToListAsync();  // order by orientation
    public async Task<Movie> GetHighestBudget() => await dbContext.Movies.OrderByDescending(m => m.Budget).FirstOrDefaultAsync(); // Highest Budget - single item
    public async Task<Movie> GetLowestBudget() => await dbContext.Movies.OrderBy(m => m.Budget).FirstOrDefaultAsync();  // Lowest Budget - single item

    public async Task<Movie> GetAverageBudget() {
        var average = await dbContext.Movies.AverageAsync(m => m.Budget);
        return await dbContext.Movies.OrderBy(m => Math.Abs(m.Budget - average)).FirstAsync();
    }

    public async Task<Movie> GetHighestCastCount() => await dbContext.Movies.OrderByDescending(m => m.NumberOfCast).FirstOrDefaultAsync(); // Highest cast for a movie

    // Get all movies for given Genre
    public async Task<List<Movie>> GetMoviesByGenre(MovieGenre genre) => await dbContext.Movies.Where(m => m.genre == genre).ToListAsync();

    //Get highest rated movie for each Genre
    public async Task<List<Movie>> GetHighestRatedMovieByGenre()   // create controller method
    {
        var genres = await dbContext.Movies
            .GroupBy(m => m.genre)  // SQL GROUP BY genre
            .Select(g => new
            {
                Genre = g.Key,
                HighestRatedMovie = g.OrderByDescending(m => m.Rating).FirstOrDefault() // Get the highest rated movie in the genre
            })
            .ToListAsync();
        return genres.Select(g => g.HighestRatedMovie).ToList();
    }
}

// highest, lowest and average budget

// Get the top rated movie

// Get the lowest rated movie

// Get the top 5 rated movies

// Get the lowest 5 rated movies

// Get the movie with the highest budget 

// Get the movie with the lowest budget 

// Get the movie with the average budget 

// Get the movie with the highest number of cast members 

// Get all the Movies for a given Genre.
// Do the Genre tast before doing this.

// Get the highest rated movie foreach Genre
// Do the Genre tast before doing this.