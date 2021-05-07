using Internship.Common.Dtos.Common;
using System;
using System.Collections.Generic;

namespace Internship.Common.Dtos
{
    public class SpecializationDto : EntityNamedDto
    {
        public ICollection<Guid> Users { get; set; }

        public ICollection<Guid> Technologies { get; set; }
    }
}
