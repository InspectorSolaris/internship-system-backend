using Internship.Common.Dtos.Common;
using System;
using System.Collections.Generic;

namespace Internship.Common.Dtos
{
    public class PositionDto : EntityDto
    {
        public int StudentsAmount { get; set; }

        public int Year { get; set; }

        public Guid CompanyId { get; set; }

        public IEnumerable<Guid> Interviews { get; set; }

        public IEnumerable<Guid> Priorities { get; set; }

        public IEnumerable<Guid> Assessments { get; set; }
    }
}
