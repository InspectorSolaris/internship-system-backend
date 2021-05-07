using Internship.Common.Dtos.Common;
using System;

namespace Internship.Common.Dtos
{
    public class InternshipAssessmentDto : EntityDto
    {
        public int Value { get; set; }

        public Guid StudentId { get; set; }

        public Guid CompanyId { get; set; }
    }
}
