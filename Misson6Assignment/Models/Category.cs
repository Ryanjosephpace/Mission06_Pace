using System.ComponentModel.DataAnnotations;

namespace Mission06_Pace.Models
{
    public class Categories
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public List<Movies>? Movies { get; set; }
    }
}
