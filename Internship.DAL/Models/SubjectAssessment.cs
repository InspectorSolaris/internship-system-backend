using Internship.DAL.Models.Common;
using Internship.DAL.Models.Identity;
using System;

namespace Internship.DAL.Models
{
    public class SubjectAssessment : Entity
    {
        public int Value { get; set; }

        public Guid SubjectInstanceId { get; set; }

        public SubjectInstance SubjectInstance { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }
    }
}
