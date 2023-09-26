namespace Writer.Tests.Mock.Models
{
    public class WriterMock
    {
        public List<Api.Models.Writer> GetAll() =>
            new List<Api.Models.Writer>()
            {
                new Api.Models.Writer
                {
                    Id = 1,
                    Name = "Leanne Graham"

                },
                new Api.Models.Writer
                {
                    Id = 2,
                    Name = "Ervin Howell"
                }
            };

        public Api.Models.Writer Get() =>
             new Api.Models.Writer
             {
                 Id = 1,
                 Name = "Leanne Graham"
             };

        public Api.Models.Writer? GetNotFound() =>
            default;

        public Api.Models.Writer Insert() =>
            new Api.Models.Writer
            {
                Id = 3,
                Name = "Glenna Reichert"
            };
    }
}