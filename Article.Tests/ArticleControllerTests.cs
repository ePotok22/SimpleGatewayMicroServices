using Article.Api.Controllers;
using Article.Api.Repositories.Interfaces;
using Article.Tests.Mock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Article.Tests
{
    [TestClass]
    public class ArticleControllerTests
    {
        [TestMethod]
        public void GivenTheGetEndpoint_WhenNoParameters_ThenReturnEveryArticles()
        {
            ArticleRepositoryMock articleRepositoryMock = new ArticleRepositoryMock()
                .GetAll();

            ArticlesController controller = InstantiateController(articleRepositoryMock);
            IActionResult? result = controller.Get();

            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public void GivenTheGetEndpoint_WhenSendIdAsParameter_ThenReturnTheArticleWithThisId()
        {
            ArticleRepositoryMock articleRepositoryMock = new ArticleRepositoryMock()
                .GetById();

            ArticlesController controller = InstantiateController(articleRepositoryMock);
            IActionResult? result = controller.Get(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public void GivenTheGetEndpoint_WhenSendNotFoundIdAsParameter_ThenReturnNotFound()
        {
            ArticleRepositoryMock articleRepositoryMock = new ArticleRepositoryMock()
                .GetByIdNotFound();

            ArticlesController controller = InstantiateController(articleRepositoryMock);
            IActionResult? result = controller.Get(99);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is NotFoundResult);
        }

        [TestMethod]
        public void GivenTheDeleteEndpoint_WhenSendIdAsParameter_ThenDeleteTheArticleWithThisId()
        {
            ArticleRepositoryMock articleRepositoryMock = new ArticleRepositoryMock()
                .Delete();

            ArticlesController controller = InstantiateController(articleRepositoryMock);
            IActionResult? result = controller.Delete(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is NoContentResult);
        }

        [TestMethod]
        public void GivenTheDeleteEndpoint_WhenSendNotFoundIdAsParameter_ThenReturnNotFound()
        {
            ArticleRepositoryMock articleRepositoryMock = new ArticleRepositoryMock()
                .DeleteNotFound();

            ArticlesController controller = InstantiateController(articleRepositoryMock);
            IActionResult? result = controller.Delete(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is NotFoundResult);
        }

        private ArticlesController InstantiateController(ArticleRepositoryMock? articleRepositoryMock = null)
        {
            Mock<IArticleRepository> mockArticle = articleRepositoryMock ?? new Mock<IArticleRepository>();
            Mock<ILogger<ArticlesController>> mockILogger = new Mock<ILogger<ArticlesController>>();

            return new ArticlesController(mockILogger.Object, mockArticle.Object);
        }
    }
}