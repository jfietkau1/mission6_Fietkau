using System.ComponentModel.DataAnnotations;

namespace mission6_Fietkau.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        
    }
}
