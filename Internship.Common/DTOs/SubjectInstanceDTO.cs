using Internship.Common.DTOs.Common;
using System;
using System.Collections.Generic;

namespace Internship.Common.DTOs
{
    public class SubjectInstanceDTO : EntityDTO
    {
        public int Year { get; set; }

        public ICollection<Guid> Users { get; set; }
    }
}
