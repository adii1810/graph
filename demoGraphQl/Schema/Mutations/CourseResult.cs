using demoGraphQl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoGraphQl.Schema.Mutations
{
    public class CourseResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subjects Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
