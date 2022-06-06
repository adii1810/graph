using demoGraphQl.DTOs;
using demoGraphQl.Models;
using demoGraphQl.Services.Courses;
using HotChocolate;
using HotChocolate.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoGraphQl.Schema.Mutations
{
    public class Mutation
    {
        private readonly CoursesRepository _coursesRepository;

        public Mutation(CoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public async Task<CourseResult> CreateCourse(string name,Subjects subject,Guid instructorId,[Service] ITopicEventSender topicEventSender)
        {
            CourseDTO courseDTO = new CourseDTO()
            {
                Name = name,
                Subject = subject,
                InstructorId = instructorId
            };

            courseDTO = await _coursesRepository.Crate(courseDTO);


            CourseResult courseType = new CourseResult()
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject,
                InstructorId = courseDTO.InstructorId,
                
            };
           await topicEventSender.SendAsync(nameof(Subscriptions.Subscriptions.CourseCreated), courseType);
            return courseType;
        }

        public async Task<CourseResult> UpdateCourse(Guid id, string name, Subjects subject,Guid instructorId)
        {
            CourseDTO courseDTO = new CourseDTO()
            {
                Id = id,
                Name = name,
                Subject = subject,
                InstructorId = instructorId
            };
            courseDTO = await _coursesRepository.Update(courseDTO);
            CourseResult courseType = new CourseResult()
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject,
                InstructorId = courseDTO.InstructorId,

            };

            return courseType;

            
            
        }
        public async Task<bool> DeleteCourse(Guid id)
        {
            return await _coursesRepository.Delete(id);
        }
    }
}
