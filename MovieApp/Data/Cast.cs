using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;

namespace MovieApp.Data;

public class Cast
{
    public int ID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }

    // one person, many movie links
    public ICollection<CastMovie> CastMovies { get; set; } = new List<CastMovie>();


    /// Challenge
    /// 
    /// Add a Cast table to the database
    /// A cast table should have the following columns:
    /// FirstName, 
    /// LastName, 
    /// Age, 
    /// AmountPaid, 
    /// Role(Lead, Supporting, Extra)
    ///
    /// These are the database relationship rule for a cast
    /// A Cast can have many movies and a Movie will have many Cast
    /// For example: 
    ///  - Daniel Radcliffe has been in every Harry Potter Movie
    ///  - All the Harry Potter Movies have multiple cast. 
    ///  
    /// Once this is complete complete the Cast Service with Dependency Injection and also Endpoints
}
