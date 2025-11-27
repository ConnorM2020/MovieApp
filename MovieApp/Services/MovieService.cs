using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Interfaces;
using System.ComponentModel.DataAnnotations;

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

    

    // highest, lowest and average budget
    // public async Task<Movie> GetAverageBudget() => await dbContext.Movies.Average( m => m.Budget).Async();


    // Get the top rated movie

    // Get the lowest rated movie

    // Get the top 5 rated movies

    // Get the lowerst 5 rated movies

    // Get the movie with the highest budget 

    // Get the movie with the lowest budget 

    // Get the movie with the average budget 

    // Get the movie with the highest number of cast memmbers 

    // Get all the Movies for a given Genre.
    // Do the Genre tast before doing this.

    // Get the highest rated movie foreach Genre
    // Do the Genre tast before doing this.
}
