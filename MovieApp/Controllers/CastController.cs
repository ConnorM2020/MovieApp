using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Interfaces;
using MovieApp.Services;

namespace MovieApp.Controllers;

// Controllers expose HTTP endpoints 
[ApiController]
[Route("[controller]")]     // Call to functions made within Movie class 
public class CastController(ICastService castService) : ControllerBase  // Controller for Cast - CastContext
{
    // Complete this controller for Casts
    [HttpGet]
    public async Task<ActionResult<List<Cast>>> GetAllCast() => await castService.GetAllCast();

    // Get all Cast for a Movie
    [HttpGet("MovieCast")]
    public async Task<ActionResult<List<Cast>>> GetMovieCast(int movieID) => await castService.GetMovieCast(movieID); // implement this function from DbSet

    [HttpGet("MovieCastMembers")]
    public async Task<ActionResult<List<string>>> GetFullNameByMovie(int movieId) => await castService.GetFullNamesByMovie(movieId);
    // Get the highest paid cast for a movie

    [HttpGet("HighestPaidCast")]
    public async Task<ActionResult<List<Cast>>> GetHighestPaidCast(int movieId) => await castService.GetHighestPaidCast(movieId);
    // Get the oldest cast for a movie

    [HttpGet("OldCastPerMovie")]
    public async Task<ActionResult<List<Cast>>> GetOldestMovieCast(int movieID) => await castService.GetOldestMovieCast(movieID);

    // Get the cast who has appeared in the most movies
    [HttpGet("MostCastAppearances")]
    public async Task<ActionResult<List<Cast>>> GetMostCastAppearances() => await castService.GetMostCastAppearances();

    [HttpGet("LowestBudget")]
    public async Task<ActionResult<List<Cast>>> GetLowestBudget() => await castService.GetLowestBudget();

    [HttpGet("AverageAgeRange")]
    public async Task<ActionResult<List<Cast>>> GetAverageAgeRange() => await castService.GetAverageAgeRange();

}

        






