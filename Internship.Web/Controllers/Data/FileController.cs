using Internship.BL.Interfaces.Data;
using Internship.Common.Dtos.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Internship.Web.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileDto> _logger;

        private readonly IFileService _fileService;

        private readonly IContentTypeProvider _contentTypeProvider;

        public FileController(
            ILogger<FileDto> logger,
            IFileService fileService,
            IContentTypeProvider contentTypeProvider)
        {
            _logger = logger;
            _fileService = fileService;
            _contentTypeProvider = contentTypeProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                if (!await _fileService.Exists(id))
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return await GetFileById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut("{userId}/{id}")]
        public async Task<IActionResult> Put(
            [FromRoute] Guid userId,
            [FromRoute] Guid id,
            IFormFile formFile)
        {
            try
            {
                using var fileStream = formFile.OpenReadStream();

                var fileDto = new FileDto()
                {
                    Id = id,
                    UserId = userId,
                    Name = Path.GetFileNameWithoutExtension(formFile.FileName),
                    Extension = Path.GetExtension(formFile.FileName),
                    CreatedAt = DateTimeOffset.UtcNow,
                    Length = formFile.Length,
                    Content = await _fileService.GetBytes(fileStream)
                };

                if (!await _fileService.Exists(fileDto.Id))
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                await _fileService.Update(fileDto);

                return await GetFileById(fileDto.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Post(
            [FromRoute] Guid userId,
            IFormFile formFile)
        {
            try
            {
                using var fileStream = formFile.OpenReadStream();

                var fileDto = new FileDto()
                {
                    UserId = userId,
                    Name = Path.GetFileNameWithoutExtension(formFile.FileName),
                    Extension = Path.GetExtension(formFile.FileName),
                    CreatedAt = DateTimeOffset.UtcNow,
                    Length = formFile.Length,
                    Content = await _fileService.GetBytes(fileStream)
                };

                var fileId = await _fileService.Create(fileDto);

                return await GetFileById(fileId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _fileService.Delete(id);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        private async Task<IActionResult> GetFileById(Guid id)
        {
            var fileDto = await _fileService.Retrieve(id);

            if (!_contentTypeProvider.TryGetContentType(fileDto.Extension, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return File(fileDto.Content, contentType, fileDto.FullName);
        }
    }
}
