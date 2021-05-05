using Internship.Common.DTOs.Common;
using System;
using System.Collections.Generic;

namespace Internship.Common.DTOs
{
    public class SpecializationDTO : EntityNamedDTO
    {
        public ICollection<Guid> Users { get; set; }

        public ICollection<Guid> Technologies { get; set; }
    }
}
