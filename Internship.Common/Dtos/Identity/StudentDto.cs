using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Internship.Common.Dtos.Identity
{
    public class StudentDto : UserDto
    {
        [Required]
        [StringLength(32, MinimumLength = 2)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 2)]
        public string LastName { get; set; }

        public IEnumerable<Guid> Interviews { get; set; }

        public IEnumerable<Guid> Priorities { get; set; }

        public IEnumerable<Guid> SubjectInstances { get; set; }

        public IEnumerable<Guid> SubjectAssessments { get; set; }

        public IEnumerable<Guid> InternshipAssessments { get; set; }
    }
}
