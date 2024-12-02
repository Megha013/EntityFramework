using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    public class Users
    {
        [Table("Users")]
        public class Employee
        {
            [Key]
            public int UserId { get; set; }
            [Required]
            [Display(Name = "Password")]
            public string? Password { get; set; }
        }
    }
}
