﻿using demoGraphQl.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demoGraphQl.DTOs
{
    public class CourseDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subjects Subject { get; set; }
        public Guid InstructorId { get; set; }
        public InstructorDTO Instructor { get; set; }
        public IEnumerable<StudentDTO> Students { get; set; }
    }
}
