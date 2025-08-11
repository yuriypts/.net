using TestNHibernate.Shema;

namespace TestNHibernate.Services.Interfaces;

public interface IRecordService
{
    Record CreateRecord(Record record);
    Record GetRecord(int id);
    Record UpdateRecord(Record record);
    void DeleteRecord(int id);
}
