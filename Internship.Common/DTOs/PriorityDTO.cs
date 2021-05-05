using Internship.Common.DTOs.Common;
using System;

namespace Internship.Common.DTOs
{
    public abstract class PriorityDTO : EntityDTO
    {
        public int Value { get; set; }

        public Guid StudentId { get; set; }

        public Guid CompanyId { get; set; }
    }
}
