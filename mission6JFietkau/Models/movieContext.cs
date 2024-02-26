using Microsoft.EntityFrameworkCore;
using mission6_Fietkau.Models;

namespace mission6JFietkau.Models
{
    public class movieContext : DbContext
    {

        public movieContext(DbContextOptions<movieContext> options): base(options){
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//seed data
        {
            modelBuilder.Entity<Category>().HasData(

                new Category { CategoryId=1, CategoryName = "Action"},
                new Category { CategoryId = 2, CategoryName = "Drama" }

                );
        }



    }
}
