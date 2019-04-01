using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    [Table("Instructor")]
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public double Salary { get; set; }

        public DateTime HireDate { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department {get; set;}
    }
}
