using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Internship.DAL.Models.Identity
{
    public class Student : User
    {
        [Required]
        [StringLength(32, MinimumLength = 2)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 2)]
        public string LastName { get; set; }

        public ICollection<Interview> Interviews { get; set; }

        public ICollection<PriorityStudent> Priorities { get; set; }

        public ICollection<InternshipAssessment> Assessments { get; set; }
    }
}
