using System;

namespace Internship.Common.Dtos.Data
{
    public class FileDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public long Length { get; set; }

        public byte[] Content { get; set; }

        public string FullName
        {
            get => $"{Name}({CreatedAt:yyyy-MM-dd-HH-mm-ss}){Extension}";
        }
    }
}
