using demoGraphQl.Schema.Mutations;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoGraphQl.Schema.Subscriptions
{
    public class Subscriptions
    {
        [Subscribe]

        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;
    }
}
