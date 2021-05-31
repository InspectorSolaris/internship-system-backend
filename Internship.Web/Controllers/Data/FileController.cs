using Internship.BL.Interfaces.Data;
using Internship.Common.Dtos.Data;
using Internship.Web.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using System;
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

        protected FileController(
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

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FilePutModel filePutModel)
        {
            try
            {
                var fileDto = new FileDto()
                {
                    Id = filePutModel.Id,
                    UserId = filePutModel.UserId,
                    Name = filePutModel.FormFile.FileName,
                    Extension = filePutModel.FormFile.ContentType,
                    Length = filePutModel.FormFile.Length,
                    Stream = filePutModel.FormFile.OpenReadStream()
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FilePostModel filePostModel)
        {
            try
            {
                var fileDto = new FileDto()
                {
                    UserId = filePostModel.UserId,
                    Name = filePostModel.FormFile.FileName,
                    Extension = filePostModel.FormFile.ContentType,
                    Length = filePostModel.FormFile.Length,
                    Stream = filePostModel.FormFile.OpenReadStream()
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

            return File(fileDto.Stream, contentType);
        }
    }
}
