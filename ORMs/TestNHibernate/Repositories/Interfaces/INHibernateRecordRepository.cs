using NHibernate_AspNetCore.Shema;

namespace NHibernate_AspNetCore.Repositories.Interfaces;

public interface INHibernateRecordRepository
{
    DBModels.NHibernateRecord Create(NHibernateRecord record);

    DBModels.NHibernateRecord Update(NHibernateRecord record);

    void Delete(NHibernateRecord record);

    DBModels.NHibernateRecord? GetBySolidId(int id);
}
