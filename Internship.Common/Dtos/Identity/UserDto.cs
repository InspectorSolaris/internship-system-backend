using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Internship.Common.Dtos.Identity
{
    public class UserDto
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

        public IEnumerable<Guid> Specializations { get; set; }

        public IEnumerable<Guid> Technologies { get; set; }

        public IEnumerable<Guid> Files { get; set; }
    }
}
