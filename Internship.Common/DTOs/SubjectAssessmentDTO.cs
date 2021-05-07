using Internship.Common.Dtos.Common;
using System;

namespace Internship.Common.Dtos
{
    public class SubjectAssessmentDto : EntityDto
    {
        public Guid SubjectId { get; set; }

        public Guid StudentId { get; set; }
    }
}
