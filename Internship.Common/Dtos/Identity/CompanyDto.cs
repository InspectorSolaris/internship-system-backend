using System;
using System.Collections.Generic;

namespace Internship.Common.Dtos.Identity
{
    public class CompanyDto : UserDto
    {
        public IEnumerable<Guid> Positions { get; set; }
    }
}
