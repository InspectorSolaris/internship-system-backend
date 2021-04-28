using Internship.DAL.Models.Common;
using Internship.DAL.Models.Identity;
using System;
using System.Collections.Generic;

namespace Internship.DAL.Models
{
    public class Position : Entity
    {
        public int StudentsAmount { get; set; }

        public int Year { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public ICollection<Interview> Interviews { get; set; }

        public ICollection<PriorityCompany> Priorities { get; set; }

        public ICollection<InternshipAssessment> Assessments { get; set; }
    }
}
