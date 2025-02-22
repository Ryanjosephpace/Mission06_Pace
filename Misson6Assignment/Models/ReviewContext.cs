using Microsoft.EntityFrameworkCore;

namespace Mission06_Pace.Models
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options) : base (options) 
        { 

        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
