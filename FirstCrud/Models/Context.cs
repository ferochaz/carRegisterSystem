using Microsoft.EntityFrameworkCore;

namespace FirstCrud.Models
{
    public class Context :DbContext
    {

            public DbSet<Car> Cars { get; set; }
        

        public Context(DbContextOptions<Context>options):base(options) { 
        
            
        
        }

    }
}
