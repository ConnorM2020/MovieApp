using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Interfaces;

namespace MovieApp.Services;
public class CastService(MovieContext dbContext) : ICastService // Complete and use this CastService
{
    // Get all Cast from CastMovies
    public async Task<List<Cast>> GetAllCast()
        => await dbContext.Casts
            .ToListAsync();

    public async Task<List<Cast>> GetMovieCast(int movieId) 
        => await dbContext.CastMovies
            .Where(cm => cm.MovieID == movieId)
            .Include(cm => cm.Cast).Select(cm => cm.Cast)                  
            .ToListAsync();

   

    // Get all Cast for a Movie
    public async Task<List<string>> GetFullNamesByMovie(int movieId)
        => await dbContext.CastMovies
            .Include(c => c.Movie)                   // load movie so MovieTitle works
            .Where(c => c.MovieID == movieId)        // filter cast by movie
            .Select(c => c.Cast.FirstName + " " + c.Cast.LastName )
            .ToListAsync();

    // Get the highest paid cast for a movie
    // Get the oldest cast for a movie
    // Get the cast who has appeared in the most movies


}
