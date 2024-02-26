using mission6_Fietkau.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace mission6JFietkau.Models
{
    public class Movie
    {
        public Movie()
        {
            MovieId = 0; // Explicitly setting the default value, but this is redundant.
        }




        [Key]
        public int MovieId { get; set; }


        //[ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } // Navigation property

        //public Category  Categories { get; set; } //brings in an instance of category so that the foreign key works
        public string Title { get; set; }

        [Range(1880, 2024, ErrorMessage = "Year must be between 1880 and 2024")]
        public int Year { get; set; }

        public string? Director {  get; set; }

        public string? Rating { get; set; }

        public int Edited { get; set; }  

        public string? LentTo { get; set; }

        public int CopiedToPlex { get; set; }

        public string? Notes {  get; set; }

    }
}
