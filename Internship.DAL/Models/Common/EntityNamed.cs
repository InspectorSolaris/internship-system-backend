using System.ComponentModel.DataAnnotations;

namespace Internship.DAL.Models.Common
{
    public class EntityNamed : Entity
    {
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
