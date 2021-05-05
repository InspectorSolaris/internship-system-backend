using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Internship.Common.DTOs.Identity
{
    public class StudentDTO : UserDTO
    {
        [Required]
        [StringLength(32, MinimumLength = 2)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 2)]
        public string LastName { get; set; }

        public ICollection<Guid> Interviews { get; set; }

        public ICollection<Guid> Priorities { get; set; }

        public ICollection<Guid> Assessments { get; set; }
    }
}
