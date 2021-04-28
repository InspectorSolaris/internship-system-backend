using Internship.DAL.Models.Common;
using Internship.DAL.Models.Identity;
using System;

namespace Internship.DAL.Models
{
    public class InternshipAssessment : Entity
    {
        public int Value { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
