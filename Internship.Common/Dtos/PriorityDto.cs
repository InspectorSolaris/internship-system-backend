using Internship.Common.Dtos.Common;
using System;

namespace Internship.Common.Dtos
{
    public abstract class PriorityDto : EntityDto
    {
        public int Value { get; set; }

        public Guid StudentId { get; set; }

        public Guid PositionId { get; set; }
    }
}
