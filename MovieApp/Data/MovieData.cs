using Microsoft.EntityFrameworkCore;

namespace MovieApp.Data;

// This holds two DbSets for Movies & Cast Members - to be used in child class 
// Represents Data Access Layer for the Database and tables 
public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; } // List of Movie [DbSet]   

    public DbSet<Cast> Casts {  get; set; }  // DbSet for Cast & Movies 
    public DbSet<CastMovie> CastMovies { get; set; }    // Connect between one - many Casts
    //  MovieContext will derive from DbContext

    // Create One to Many relationship - One Movie - Many Actors 
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<CastMovie>()
        .HasOne(cm => cm.Cast)
        .WithMany(c => c.CastMovies)
        .HasForeignKey(cm => cm.CastID);

    modelBuilder.Entity<CastMovie>()
        .HasOne(cm => cm.Movie)
        .WithMany(m => m.CastMovies)
        .HasForeignKey(cm => cm.MovieID);
    }


}
