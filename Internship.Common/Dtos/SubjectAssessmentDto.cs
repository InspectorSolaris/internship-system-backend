using Internship.Common.Dtos.Common;
using System;

namespace Internship.Common.Dtos
{
    public class SubjectAssessmentDto : EntityDto
    {
        public int Value { get; set; }

        public Guid SubjectInstanceId { get; set; }

        public Guid StudentId { get; set; }
    }
}
