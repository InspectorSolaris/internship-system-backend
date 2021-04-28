using Internship.DAL.Models.Common;
using Internship.DAL.Models.Identity;
using System.Collections.Generic;

namespace Internship.DAL.Models
{
    public class Specialization : EntityNamed
    {
        public ICollection<User> Users { get; set; }

        public ICollection<Technology> Technologies { get; set; }
    }
}
