using Internship.Common.DTOs.Common;
using System;
using System.Collections.Generic;

namespace Internship.Common.DTOs
{
    public class TechnologyDTO : EntityNamedDTO
    {
        public Guid SpecializationId { get; set; }

        public ICollection<Guid> Users { get; set; }
    }
}
