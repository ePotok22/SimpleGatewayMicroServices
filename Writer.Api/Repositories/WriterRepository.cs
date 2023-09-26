using Writer.Api.Repositories.Interfaces;
using WriterModel = Writer.Api.Models.Writer;

namespace Writer.Api.Repositories
{
    public class WriterRepository : List<WriterModel>, IWriterRepository
    {
        private readonly static List<WriterModel> _writers = Populate();

        private static List<WriterModel> Populate() =>
             new List<WriterModel>
            {
                new WriterModel
                {
                    Id = 1,
                    Name = "Leanne Graham"
                },
                new WriterModel
                {
                    Id = 2,
                    Name = "Ervin Howell"
                },
                new WriterModel
                {
                    Id = 3,
                    Name = "Glenna Reichert"
                }
            };

        public List<WriterModel> GetAll() =>
            _writers;

        public WriterModel Insert(WriterModel writer)
        {
            int maxId = _writers.Max(x => x.Id);

            writer.Id = ++maxId;
            _writers.Add(writer);

            return writer;
        }

        public WriterModel? Get(int id) =>
            _writers.FirstOrDefault(x => x.Id == id);
    }
}