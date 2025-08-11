using TestNHibernate.Shema;

namespace TestNHibernate.Repositories.Interfaces;

public interface IRecordRepository
{
    DBModels.Record Create(Record record);

    DBModels.Record Update(Record record);

    void Delete(Record record);

    DBModels.Record? GetBySolidId(int id);
}
