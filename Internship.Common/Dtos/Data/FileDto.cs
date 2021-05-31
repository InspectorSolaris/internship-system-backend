using Internship.Common.Dtos.Identity;
using System;
using System.IO;

namespace Internship.Common.Dtos.Data
{
    public class FileDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public long Length { get; set; }

        public Stream Stream { get; set; }
    }
}
