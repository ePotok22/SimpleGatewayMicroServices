using Microsoft.AspNetCore.Mvc;
using WriterModel = Writer.Api.Models.Writer;
using Writer.Api.Repositories.Interfaces;

namespace Writer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly IWriterRepository _writerRepository;
        private readonly ILogger<WritersController> _logger;

        public WritersController(ILogger<WritersController> logger, IWriterRepository writerRepository)
        {
            _logger = logger;
            _writerRepository = writerRepository;
        }

        [HttpGet]
        public IActionResult Get() =>
            Ok(_writerRepository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            WriterModel? writer = _writerRepository.Get(id);

            if (writer is null)
                return NotFound();

            return Ok(writer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] WriterModel writer)
        {
            WriterModel? result = _writerRepository.Insert(writer);

            return Created($"/get/{result.Id}", result);
        }

    }
}