using Microsoft.AspNetCore.Mvc.Rendering;
using mvcD2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcD2.ViewModels
{
    public class employeeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(23,55)]
        public int Age { get; set; }
        public string? Address { get; set; }
        public double? Salary { get; set; }
        [Required]
        public string? email { get; set; }

        [RegularExpression("^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9 ]{8,}$")]
        //Minimum eight characters, at least one letter and one number
        public string password { get; set; }
        [Compare("password")]
        public string confirmPassword { get; set; }

        [Display(Name="Office")]
        public int? office_id { get; set; }
        public SelectList offices { get; set; }


    }
}
