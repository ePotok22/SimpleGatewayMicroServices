using Article.Api.Repositories.Interfaces;
using ArticleModel = Article.Api.Models.Article;
using Microsoft.AspNetCore.Mvc;

namespace Article.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ILogger<ArticlesController> _logger;
        public ArticlesController(ILogger<ArticlesController> logger, IArticleRepository articleRepository)
        {
            _logger = logger;
            _articleRepository = articleRepository;
        }

        [HttpGet]
        public IActionResult Get() =>
            Ok(_articleRepository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ArticleModel? article = _articleRepository.Get(id);

            if (article is null)
                return NotFound();

            return Ok(article);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int deletedId = _articleRepository.Delete(id);

            if (deletedId.Equals(0))
                return NotFound();

            return NoContent();
        }
    }
}