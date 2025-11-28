using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Interfaces;
using MovieApp.Services;

namespace MovieApp.Controllers;

// Controllers expose HTTP endpoints 
[ApiController]
[Route("[controller]")]     // Call to functions made within MOovie class 
public class CastController(ICastService castService) : ControllerBase  // Controller for Cast - CastContext
{
    // Complete this controller for Casts
    [HttpGet]
    public async Task<ActionResult<List<Cast>>> GetAllCast() => await castService.GetAllCast();

    [HttpGet("MovieCast")]
    public async Task<ActionResult<List<Cast>>> GetMovieCast(int movieID) => await castService.GetMovieCast(movieID); // implement this function from DbSet

    
    [HttpGet("MovieCastMembers")]
    public async Task<ActionResult<List<string>>> GetFullNameByMovie(int movieId) => await castService.GetFullNamesByMovie(movieId);

}

        






