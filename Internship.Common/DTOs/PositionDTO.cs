using Internship.Common.DTOs.Common;
using System;
using System.Collections.Generic;

namespace Internship.Common.DTOs
{
    public class PositionDTO : EntityDTO
    {
        public int StudentsAmount { get; set; }

        public int Year { get; set; }

        public Guid CompanyId { get; set; }

        public ICollection<Guid> Interviews { get; set; }

        public ICollection<Guid> Priorities { get; set; }

        public ICollection<Guid> Assessments { get; set; }
    }
}
