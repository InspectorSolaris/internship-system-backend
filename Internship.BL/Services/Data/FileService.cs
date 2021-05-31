using Internship.BL.Interfaces.Data;
using Internship.Common.Dtos.Data;
using Internship.DAL.Context;
using Internship.DAL.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Internship.BL.Services.Data
{
    public class FileService : IFileService
    {
        public readonly InternshipDbContext _context;

        public readonly IConfiguration _configuration;

        public readonly IHostEnvironment _hostEnvironment;

        public FileService(
            InternshipDbContext context,
            IConfiguration configuration,
            IHostEnvironment hostEnvironment)
        {
            _context = context;
            _configuration = configuration;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<Guid> Create(FileDto fileDto)
        {
            var file = new File()
            {
                Id = Guid.NewGuid(),
                UserId = fileDto.UserId,
                Name = fileDto.Name,
                Extension = fileDto.Extension,
                Length = fileDto.Length
            };

            var filePath = GetFilePath(file);

            fileDto.Stream.CopyTo(System.IO.File.Create(filePath));

            await _context.AddAsync(file);
            await _context.SaveChangesAsync();

            return file.Id;
        }

        public async Task<FileDto> Retrieve(Guid id)
        {
            var file = await _context.Files
                .FirstOrDefaultAsync(file => file.Id == id);

            if (file == null)
            {
                return null;
            }

            var filePath = GetFilePath(file);

            if (!System.IO.File.Exists(filePath))
            {
                return null;
            }

            var fileStream = System.IO.File.OpenRead(filePath);

            return new FileDto()
            {
                Id = file.Id,
                UserId = file.UserId,
                Name = file.Name,
                Extension = file.Extension,
                Length = file.Length,
                Stream = fileStream
            };
        }

        public async Task Update(FileDto fileDto)
        {
            var file = await _context.Files
                .FirstOrDefaultAsync(file => file.Id == fileDto.Id);

            if (file == null)
            {
                return;
            }

            var filePath = GetFilePath(file);

            fileDto.Stream.CopyTo(System.IO.File.Create(filePath));
        }

        public async Task Delete(Guid id)
        {
            var file = await _context.Files
                .FirstOrDefaultAsync(file => file.Id == id);

            var filePath = GetFilePath(file);

            if (!System.IO.File.Exists(filePath))
            {
                return;
            }

            System.IO.File.Delete(filePath);
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Files.AnyAsync(file => file.Id == id);
        }

        private string GetFilePath(File file)
        {
            return System.IO.Path.Combine(_hostEnvironment.ContentRootPath, _configuration["Storage:Data"], $"{file.Name}{file.Extension}");
        }
    }
}
