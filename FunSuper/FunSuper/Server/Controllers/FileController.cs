using FunSuper.Server.Services;
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
        public async Task<ActionResult> ImportFile([FromForm] IFormFile file)
        {
            // Read spreadsheet
            var dataSet = await _fileService.ReadSpreadSheetAsync(file.OpenReadStream());

            await _contextSeedService.SeedSuperContext(dataSet);

            return new OkResult();
        }
    }
}