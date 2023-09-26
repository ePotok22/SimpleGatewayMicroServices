using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Writer.Api.Controllers;
using Writer.Api.Repositories.Interfaces;
using Writer.Tests.Mock;

namespace Writer.Tests
{
    [TestClass]
    public class WritersControllerTests
    {
        [TestMethod]
        public void GivenTheGetEndpoint_WhenNoParameters_ThenReturnEveryWriters()
        {
            WriterRepositoryMock writerRepositoryMock = new WriterRepositoryMock()
                .GetAll();

            WritersController controller = InstantiateController(writerRepositoryMock);
            IActionResult? result = controller.Get();

            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public void GivenTheGetEndpoint_WhenSendIdAsParameter_ThenReturnTheWriterWithThisId()
        {
            WriterRepositoryMock writerRepositoryMock = new WriterRepositoryMock()
                .GetById();

            WritersController controller = InstantiateController(writerRepositoryMock);
            IActionResult? result = controller.Get(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public void GivenTheGetEndpoint_WhenSendNotFoundIdAsParameter_ThenReturnNotFound()
        {
            WriterRepositoryMock writerRepositoryMock = new WriterRepositoryMock()
                .GetByIdNotFound();

            WritersController controller = InstantiateController(writerRepositoryMock);
            IActionResult? result = controller.Get(999);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is NotFoundResult);
        }

        [TestMethod]
        public void GivenThePostEndpoint_WhenSendData_ThenCreateNewWriter()
        {
            WriterRepositoryMock writerRepositoryMock = new WriterRepositoryMock()
               .InsertWriter();

            WritersController controller = InstantiateController(writerRepositoryMock);
            IActionResult? result = controller.Post(new Writer.Api.Models.Writer { Id = 0, Name = "New Writer" });

            Assert.IsNotNull(result);
            Assert.IsTrue(result is CreatedResult);
        }

        public WritersController InstantiateController(WriterRepositoryMock? writerRepositoryMock = null)
        {
            Mock<IWriterRepository> mockWriter = writerRepositoryMock ?? new Mock<IWriterRepository>();
            Mock<ILogger<WritersController>> mockLogger =  new Mock<ILogger<WritersController>>();

            return new WritersController(mockLogger.Object, mockWriter.Object);
        }
    }
}