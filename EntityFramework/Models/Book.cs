using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    [Table("book")]
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [Display(Name = "Book Name")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Author")]
        public string? Author { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string? Category { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}
