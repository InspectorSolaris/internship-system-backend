using Internship.Common.Dtos.Common;
using Internship.Common.Enums;
using System;

namespace Internship.Common.Dtos
{
    public class InterviewDto : EntityDto
    {
        public InterviewResult Result { get; set; }

        public Guid StudentId { get; set; }

        public Guid CompanyId { get; set; }
    }
}
