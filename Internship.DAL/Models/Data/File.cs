using Internship.DAL.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internship.DAL.Models.Data
{
    public class File
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public long Length { get; set; }

        [NotMapped]
        public string FullName
        {
            get => $"{Name}({CreatedAt:yyyy-MM-dd-HH-mm-ss}){Extension}";
        }
    }
}
