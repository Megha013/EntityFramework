﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "Employee Salary")]
        public double Salary { get; set; }
    }
}
