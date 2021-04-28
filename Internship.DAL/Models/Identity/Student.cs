using System.Collections.Generic;

namespace Internship.DAL.Models.Identity
{
    public class Student : User
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public ICollection<Interview> Interviews { get; set; }

        public ICollection<PriorityStudent> Priorities { get; set; }

        public ICollection<InternshipAssessment> Assessments { get; set; }
    }
}
