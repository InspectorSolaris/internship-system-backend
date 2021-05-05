using System.ComponentModel.DataAnnotations;

namespace Internship.Common.DTOs.Identity
{
    public class HITsWorkerDTO : UserDTO
    {
        [Required]
        [StringLength(32, MinimumLength = 2)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
