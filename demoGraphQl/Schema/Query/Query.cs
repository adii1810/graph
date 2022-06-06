using Bogus;
using demoGraphQl.Models;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoGraphQl.Schema
{
    public class Query
    {
        private readonly Faker<InstructorType> _instructorFaker;
        private readonly Faker<StudentType> _studentFaker;
        private readonly Faker<CourseType> _courseFaker;

        public Query()
        {
            _instructorFaker = new Faker<InstructorType>()
                .RuleFor(c => c.guid, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Salary, f => f.Random.Double(1, 100000));
            _studentFaker = new Faker<StudentType>()
                .RuleFor(c => c.guid, c => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.GPA, f => f.Random.Double(1, 4));

            _courseFaker = new Faker<CourseType>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Name.JobTitle())
                .RuleFor(c => c.Subject, f => f.PickRandom<Subjects>())
                .RuleFor(c => c.Instructor, f => _instructorFaker.Generate())
                .RuleFor(c => c.Students, f => _studentFaker.Generate(3));
        }
        public IEnumerable<CourseType> GetCourses() {

            
            List<CourseType> courses = _courseFaker.Generate(5);
            return courses;
        }

        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            await Task.Delay(1000);
            CourseType course = _courseFaker.Generate();
            course.Id = id;
            return course;
        }
        [GraphQLDeprecated("This query is deprecated")]
        public string Instructions => "Hello World";
    }
}
