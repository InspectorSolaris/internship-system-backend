using Internship.Common.DTOs.Common;
using System;

namespace Internship.Common.DTOs
{
    public class SubjectAssessmentDTO : EntityDTO
    {
        public Guid SubjectId { get; set; }

        public Guid StudentId { get; set; }
    }
}
