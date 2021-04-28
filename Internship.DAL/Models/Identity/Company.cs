using System.Collections.Generic;

namespace Internship.DAL.Models.Identity
{
    public class Company : User
    {
        public ICollection<Position> Positions { get; set; }
    }
}
