using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoGraphQl.Schema
{
    public class StudentType
    {
        public Guid guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [GraphQLName("gpa")]
        public double GPA { get; set; }
    }
}
