using demoGraphQl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoGraphQl.Schema
{

    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subjects Subject { get; set; }
        public InstructorType Instructor { get; set; }
        public IEnumerable<StudentType> Students { get; set; }
    }
}
