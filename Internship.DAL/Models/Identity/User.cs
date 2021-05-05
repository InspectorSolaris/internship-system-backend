using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Internship.DAL.Models.Identity
{
    public class User : IdentityUser<Guid>
    {
        [StringLength(1024)]
        public string Info { get; set; }

        public ICollection<Specialization> Specializations { get; set; }

        public ICollection<Technology> Technologies { get; set; }

        public ICollection<SubjectInstance> SubjectInstances { get; set; }
    }
}
