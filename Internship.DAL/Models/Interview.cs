using Internship.Common.Enums;
using Internship.DAL.Models.Common;
using Internship.DAL.Models.Identity;
using System;

namespace Internship.DAL.Models
{
    public class Interview : Entity
    {
        public InterviewResult Result { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
