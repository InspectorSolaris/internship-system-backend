using Internship.Common.Dtos.Common;
using System.ComponentModel.DataAnnotations;

namespace Internship.Common.Dtos
{
    public class SubjectDto : EntityDto
    {
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
