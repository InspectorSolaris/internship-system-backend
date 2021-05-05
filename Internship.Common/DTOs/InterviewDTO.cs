using Internship.Common.DTOs.Common;
using Internship.Common.Enums;
using System;

namespace Internship.Common.DTOs
{
    public class InterviewDTO : EntityDTO
    {
        public InterviewResult Result { get; set; }

        public Guid StudentId { get; set; }

        public Guid CompanyId { get; set; }
    }
}
