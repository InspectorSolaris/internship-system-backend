using Internship.DAL.Models.Common;
using Internship.DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Internship.DAL.Models
{
    [Index(nameof(Value), IsUnique = true)]
    public abstract class Priority : Entity
    {
        public int Value { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public Guid PositionId { get; set; }

        public Position Position { get; set; }
    }
}
