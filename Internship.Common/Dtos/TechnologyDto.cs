using Internship.Common.Dtos.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Internship.Common.Dtos
{
    public class TechnologyDto : EntityDto
    {
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string Name { get; set; }

        public IEnumerable<Guid> Users { get; set; }
    }
}
