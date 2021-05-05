using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Internship.Common.DTOs.Identity
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 4)]
        public string Email { get; set; }

        [StringLength(1024)]
        public string Info { get; set; }

        public ICollection<Guid> Specializations { get; set; }

        public ICollection<Guid> Technologies { get; set; }

        public ICollection<Guid> SubjectInstances { get; set; }
    }
}
