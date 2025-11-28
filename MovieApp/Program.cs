using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Interfaces;
using MovieApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IMovieService, MovieService>();
// Add Cast to scope 
builder.Services.AddScoped<ICastService, CastService>();


builder.Services.AddControllers();
builder.Services.AddDbContext<MovieContext>(opt => opt.UseInMemoryDatabase("MovieDB"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Await for both seed data contents - Movie + Cast data 
await MovieSeedData.SeedData(builder.Services);
await CastSeedData.SeedData(builder.Services);
await CastMovieSeedData.SeedData(builder.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
