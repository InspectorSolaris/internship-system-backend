using Internship.Common.Enums;
using Internship.DAL.Models.Common;
using Internship.DAL.Models.Identity;
using System;

namespace Internship.DAL.Models
{
    public class Interview : Entity
    {
        public DateTimeOffset? Date { get; set; }

        public InterviewState State { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public Guid PositionId { get; set; }

        public Position Position { get; set; }
    }
}
