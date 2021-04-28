using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Internship.DAL.Models.Identity
{
    public abstract class User : IdentityUser<Guid>
    {
        public string Info { get; set; }

        public ICollection<Specialization> Specializations { get; set; }

        public ICollection<Technology> Technologies { get; set; }

        public ICollection<SubjectInstance> SubjectInstances { get; set; }
    }
}
