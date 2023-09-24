using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcD2.Models
{
    [PrimaryKey("emp_id","proj_id")]
    public class Emp_project
    {
        [ForeignKey("Employee")]
        public int emp_id {  get; set; }
        [ForeignKey("Project")]
        public int proj_id { get; set; }
        public int? workingHours { get; set; }

        public Employee Employee { get; set; }
        public Project project { get; set; }

    }
}
