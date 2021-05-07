using Internship.DAL.Models.Common;
using Internship.DAL.Models.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Internship.DAL.Models
{
    public class Specialization : Entity
    {
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Technology> Technologies { get; set; }
    }
}
