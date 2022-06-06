using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demoGraphQl.DTOs
{
    public class StudentDTO
    {
        [Key]
        public Guid guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public double GPA { get; set; }
        public IEnumerable<CourseDTO> Courses { get; set; }
    }
}
