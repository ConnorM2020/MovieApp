using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Interfaces;
using System.Text.RegularExpressions;

namespace MovieApp.Services;
public class CastService(MovieContext dbContext) : ICastService // Inherit from ICastService interface
{
    // Get all Cast from CastMovies
    public async Task<List<Cast>> GetAllCast() => await dbContext.Casts.ToListAsync();
    public async Task<List<Cast>> GetMovieCast(int movieId) => await dbContext.CastMovies.Where(cm => cm.MovieID == movieId).Include(cm => cm.Cast).Select(cm => cm.Cast).ToListAsync();

    // Get all Cast for a Movie
    public async Task<List<string>> GetFullNamesByMovie(int movieId)    // Extra representation for MovieCast
        => await dbContext.CastMovies
            .Include(c => c.Movie)                   // load movie so MovieTitle works
            .Where(c => c.MovieID == movieId)        // filter cast by movie
            .Select(c => c.Cast.FirstName + " " + c.Cast.LastName )
            .ToListAsync();

    // Get the highest paid cast for a movie - WORKING
    // first get as variable , then print to await - do for all below
    // find the instance then compare with return await and .select(cm => cm.cast) returning entire cast
    public async Task<List<Cast>> GetHighestPaidCast(int movieId)
    {
        var maxPay = await dbContext.CastMovies 
            .Where(cm => cm.MovieID == movieId)
            .MaxAsync(cm => cm.Cast.AmountPaid);

        return await dbContext.CastMovies
            .Where(cm => cm.MovieID == movieId && cm.Cast.AmountPaid == maxPay)
            .Select(cm => cm.Cast)
            .ToListAsync();
    }
    // SELECT from Cast, where Max(amountPaid) GROUP BY MOVIE
    //  Get the oldest cast for a movie - WORKING
    public async Task<List<Cast>> GetOldestMovieCast(int movieID)
    {
        var oldestCast = await dbContext.CastMovies.Where(cm => cm.Movie.ID == movieID).MaxAsync(cm => cm.Cast.Age);

        return await dbContext.CastMovies.
            Where(cm => cm.MovieID == movieID && cm.Cast.Age == oldestCast)
            .Select(cm => cm.Cast)
            .ToListAsync();
    }
    // Get the cast who has appeared in the most movies - WORKING for Harry Potter series 
    public async Task<List<Cast>> GetMostCastAppearances()
    {
        var maxAppearances = await dbContext.CastMovies
            .GroupBy(cm => cm.CastID)
            .Select(g => new { CastID = g.Key, AppearanceCount = g.Count() })
            .MaxAsync(g => g.AppearanceCount);

        var castIds = await dbContext.CastMovies
            .GroupBy(cm => cm.CastID)
            .Where(g => g.Count() == maxAppearances)
            .Select(g => g.Key)
            .ToListAsync();

        return await dbContext.Casts
            .Where(c => castIds.Contains(c.ID))
            .ToListAsync();
    }

    // Additional function for further understanding - first define variable then make .Where() comparison
    public async Task<List<Cast>> GetLowestBudget()
    {
        var lowestBudget = await dbContext.Casts.MinAsync(m => m.AmountPaid);
        return await dbContext.Casts.Where(m => m.AmountPaid == lowestBudget).ToListAsync();
    }

    public async Task<List<Cast>> GetAverageAgeRange()   // .Where(c => ageRange.Contains(c.Age))
        => await dbContext.Casts.Where(c => c.Age >= 20 && c.Age >= 65).ToListAsync();

}
