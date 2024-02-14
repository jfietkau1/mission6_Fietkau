using Microsoft.EntityFrameworkCore;

namespace mission6JFietkau.Models
{
    public class movieContext : DbContext
    {

        public movieContext(DbContextOptions<movieContext> options): base(options){
        }
        public DbSet<Movie> Movies { get; set; }
             
    }
}
