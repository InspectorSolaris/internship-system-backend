using System;
using System.Collections.Generic;

namespace Internship.Common.Dtos.Identity
{
    public class CompanyDto : UserDto
    {
        public ICollection<Guid> Positions { get; set; }
    }
}
