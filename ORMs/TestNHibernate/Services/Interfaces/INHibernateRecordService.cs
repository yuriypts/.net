using NHibernate_AspNetCore.Shema;

namespace NHibernate_AspNetCore.Services.Interfaces;

public interface INHibernateRecordService
{
    NHibernateRecord CreateRecord(NHibernateRecord record);
    NHibernateRecord GetRecord(int id);
    NHibernateRecord UpdateRecord(NHibernateRecord record);
    void DeleteRecord(int id);
}
