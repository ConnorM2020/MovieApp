using Microsoft.EntityFrameworkCore;

namespace MovieApp.Data
{
    public static class CastSeedData
    {
        public static async Task SeedData(IServiceCollection services)
        {
            var dbContext = services.BuildServiceProvider()
                                    .CreateScope()
                                    .ServiceProvider
                                    .GetService<MovieContext>();

            var castMembers = new List<Cast>
            {
                // HARRY POTTER – main trio
                new Cast { ID = 1, FirstName = "Daniel",  LastName = "Radcliffe", Age = 33, AmountPaid = 10000000, Role = "Lead" },
                new Cast { ID = 2, FirstName = "Emma",    LastName = "Watson",    Age = 32, AmountPaid =  9000000, Role = "Supporting" },
                new Cast { ID = 3, FirstName = "Rupert",  LastName = "Grint",     Age = 34, AmountPaid =  8500000, Role = "Supporting" },

                // Harry Potter – supporting             
                new Cast { ID = 4, FirstName = "Alan",    LastName = "Rickman",   Age = 69, AmountPaid =  7000000, Role = "Supporting" },
                new Cast { ID = 5, FirstName = "Tom",     LastName = "Felton",    Age = 35, AmountPaid =  3000000, Role = "Supporting" },
                new Cast { ID = 6, FirstName = "Gary",    LastName = "Oldman",    Age = 65, AmountPaid =  6000000, Role = "Supporting" },
                new Cast { ID = 7, FirstName = "Evanna",  LastName = "Lynch",     Age = 31, AmountPaid =  1500000, Role = "Supporting" },
                new Cast { ID = 8, FirstName = "Ralph",   LastName = "Fiennes",   Age = 60, AmountPaid =  8000000, Role = "Lead" },

                // EXTRA Harry Potter roles          
                new Cast { ID = 19, FirstName = "Maggie",  LastName = "Smith",    Age = 88, AmountPaid =  5000000, Role = "Extra" },
                new Cast { ID = 20, FirstName = "Matthew", LastName = "Lewis",    Age = 34, AmountPaid =  2000000, Role = "Extra" },

                // LORD OF THE RINGS              
                new Cast { ID = 9,  FirstName = "Elijah", LastName = "Wood",      Age = 42, AmountPaid =  7000000, Role = "Lead" },
                new Cast { ID = 10, FirstName = "Ian",    LastName = "McKellen",  Age = 84, AmountPaid =  5000000, Role = "Supporting" },
                new Cast { ID = 11, FirstName = "Viggo",  LastName = "Mortensen", Age = 64, AmountPaid =  6000000, Role = "Supporting" },
                new Cast { ID = 12, FirstName = "Sean",   LastName = "Astin",     Age = 51, AmountPaid =  4000000, Role = "Supporting" },
                new Cast { ID = 13, FirstName = "Andy",   LastName = "Serkis",    Age = 58, AmountPaid =  4500000, Role = "Supporting" },

                // EXTRA LOTR roles            
                new Cast { ID = 21, FirstName = "Orlando", LastName = "Bloom",    Age = 46, AmountPaid =  4500000, Role = "Extra" },
                new Cast { ID = 22, FirstName = "Cate",    LastName = "Blanchett",Age = 54, AmountPaid =  4800000, Role = "Extra" },

              
                // BATMAN TRILOGY              
                new Cast { ID = 14, FirstName = "Christian", LastName = "Bale",   Age = 49, AmountPaid = 15000000, Role = "Lead" },
                new Cast { ID = 15, FirstName = "Liam",      LastName = "Neeson", Age = 71, AmountPaid =  4000000, Role = "Supporting" },
                new Cast { ID = 16, FirstName = "Michael",   LastName = "Caine",  Age = 90, AmountPaid =  5000000, Role = "Supporting" },
                new Cast { ID = 17, FirstName = "Heath",     LastName = "Ledger", Age = 28, AmountPaid =  5000000, Role = "Supporting" },
                new Cast { ID = 18, FirstName = "Tom",       LastName = "Hardy",  Age = 45, AmountPaid =  6000000, Role = "Supporting" },

             
                // EXTRA Batman roles            
                new Cast { ID = 23, FirstName = "Morgan", LastName = "Freeman",   Age = 86, AmountPaid =  5500000, Role = "Extra" },
                new Cast { ID = 24, FirstName = "Anne",   LastName = "Hathaway",  Age = 40, AmountPaid =  5000000, Role = "Extra" }
            };

            await dbContext.Casts.AddRangeAsync(castMembers);
            await dbContext.SaveChangesAsync();
        }
    }
}
// HARRY POTTER – main trio 


// Harry Potter – supporting
// EXTRA Harry Potter roles


// LORD OF THE RINGS
// EXTRA LOTR roles

// BATMAN TRILOGY
// EXTRA Batman roles