using Internship.Common.Dtos.Common;
using Internship.Common.Enums;
using System;

namespace Internship.Common.Dtos
{
    public class InterviewDto : EntityDto
    {
        public DateTimeOffset? Date { get; set; }

        public InterviewState State { get; set; }

        public Guid StudentId { get; set; }

        public Guid PositionId { get; set; }
    }
}
