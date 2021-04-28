using Internship.DAL.Models.Common;
using Internship.DAL.Models.Identity;
using System;
using System.Collections.Generic;

namespace Internship.DAL.Models
{
    public class Technology : EntityNamed
    {
        public ICollection<User> Users { get; set; }

        public Guid SpecializationId { get; set; }

        public Specialization Specialization { get; set; }
    }
}
