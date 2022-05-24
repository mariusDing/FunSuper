using FunSuper.Server.Services;
using FunSuper.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FunSuper.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IContextSeedService _contextSeedService;
        public FileController(IFileService fileService, IContextSeedService contextSeedService)
        {
            _fileService = fileService;
            _contextSeedService = contextSeedService;
        }

        /// <summary>
        /// Ingest data from spreadsheet
        /// </summary>
        [HttpPost("import")]
        public async Task<FileImportResult> ImportFile([FromForm] IFormFile file)
        {
            // Read data from spreadsheet
            var dataSet = await _fileService.ReadSpreadSheetAsync(file.OpenReadStream());

            // Import data to context
            var result = await _contextSeedService.SeedSuperContext(dataSet);

            return new FileImportResult
            {
                EmployeeIds = result.EmployeeIds
            };
        }
    }
}