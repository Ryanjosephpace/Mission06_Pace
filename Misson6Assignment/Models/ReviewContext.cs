using Microsoft.EntityFrameworkCore;

namespace Mission06_Pace.Models
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options) : base (options) 
        { 

        }

        public DbSet<Review> Reviews { get; set; }
    }
}
