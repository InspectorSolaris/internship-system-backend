using Internship.Common.Dtos.Common;
using System;
using System.Collections.Generic;

namespace Internship.Common.Dtos
{
    public class TechnologyDto : EntityNamedDto
    {
        public Guid SpecializationId { get; set; }

        public ICollection<Guid> Users { get; set; }
    }
}
