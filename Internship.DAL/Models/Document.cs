using Internship.DAL.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Internship.DAL.Models
{
    public class Document : Entity
    {
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
