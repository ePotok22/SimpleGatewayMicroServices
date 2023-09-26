using WriterModel = Writer.Api.Models.Writer;

namespace Writer.Api.Repositories.Interfaces
{
    public interface IWriterRepository
    {
        List<WriterModel> GetAll();
        WriterModel? Get(int id);
        WriterModel Insert(WriterModel writer);
    }
}