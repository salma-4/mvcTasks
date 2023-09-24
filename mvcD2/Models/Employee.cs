using System.ComponentModel.DataAnnotations.Schema;

namespace mvcD2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public double? Salary { get; set; }
        public string? email { get; set; }
        public string password { get; set; }

        [ForeignKey("Office")]
        public int? office_id { get; set; }


        public Office? Office { get; set; }
        public List<Emp_project> projects { get; set; }

    }
}
