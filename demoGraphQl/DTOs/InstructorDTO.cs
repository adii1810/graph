using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demoGraphQl.DTOs
{
    public class InstructorDTO
    {
        [Key]
        public Guid guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public IEnumerable<CourseDTO> Courses { get; set; }
    }
}
