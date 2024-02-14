using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace mission6JFietkau.Models
{
    public class Movie
    {
        [Key]
        public string category { get; set; }

        public string title { get; set; }

        public int year { get; set; }

        public String director {  get; set; }

        public string rating { get; set; }

        public string? edited { get; set; }  

        public string? lent_to { get; set; }

        public string? notes {  get; set; }

    }
}
