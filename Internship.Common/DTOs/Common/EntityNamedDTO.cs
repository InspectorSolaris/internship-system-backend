using System.ComponentModel.DataAnnotations;

namespace Internship.Common.DTOs.Common
{
    public class EntityNamedDTO
    {
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
