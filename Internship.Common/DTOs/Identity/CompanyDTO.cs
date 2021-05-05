using System;
using System.Collections.Generic;

namespace Internship.Common.DTOs.Identity
{
    public class CompanyDTO : UserDTO
    {
        public ICollection<Guid> Positions { get; set; }
    }
}
