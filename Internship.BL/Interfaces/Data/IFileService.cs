using Internship.Common.Dtos.Data;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Internship.BL.Interfaces.Data
{
    public interface IFileService
    {
        Task<Guid> Create(FileDto fileDto);

        Task<FileDto> Retrieve(Guid id);

        Task Update(FileDto fileDto);

        Task Delete(Guid id);

        Task<bool> Exists(Guid id);

        Task<byte[]> GetBytes(Stream stream);
    }
}
