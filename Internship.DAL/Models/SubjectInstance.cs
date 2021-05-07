using Internship.DAL.Models.Common;
using Internship.DAL.Models.Identity;
using System.Collections.Generic;

namespace Internship.DAL.Models
{
    public class SubjectInstance : Entity
    {
        public int Year { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
