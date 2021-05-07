using System.ComponentModel.DataAnnotations;

namespace Internship.Common.Dtos.Common
{
    public class EntityNamedDto
    {
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
