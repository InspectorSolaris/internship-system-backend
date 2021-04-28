using Internship.DAL.Models.Common;
using Internship.DAL.Models.Identity;
using System;

namespace Internship.DAL.Models
{
    public class SubjectAssessment : Entity
    {
        public Guid SubjectId { get; set; }

        public Subject Subject { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }
    }
}
