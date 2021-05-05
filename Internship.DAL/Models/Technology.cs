using Internship.DAL.Models.Common;
using Internship.DAL.Models.Identity;
using System;
using System.Collections.Generic;

namespace Internship.DAL.Models
{
    public class Technology : EntityNamed
    {
        public Guid SpecializationId { get; set; }

        public Specialization Specialization { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
