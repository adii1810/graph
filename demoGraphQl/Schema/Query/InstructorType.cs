using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoGraphQl.Schema
{
    public class InstructorType
    {
        public Guid guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }

    }
}
