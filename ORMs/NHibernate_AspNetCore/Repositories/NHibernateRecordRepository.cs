using NHibernate;
using NHibernate_AspNetCore.Repositories.Interfaces;
using NHibernate_AspNetCore.SessionFactory.Interfaces;
using NHibernate_AspNetCore.Shema;

namespace NHibernate_AspNetCore.Repositories;

public class NHibernateRecordRepository : INHibernateRecordRepository
{
    private readonly NHibernate.ISession _session;

    public NHibernateRecordRepository(INHibernateSessionFactory nHibernateSessionFactory)
    {
        _session = nHibernateSessionFactory.SessionFactory.OpenSession();
    }

    public DBModels.NHibernateRecord Create(NHibernateRecord record)
    {
        DBModels.NHibernateRecord dbRecord = new DBModels.NHibernateRecord
        {
            SolidId = record.SolidId,
            Name = record.Name
        };

        using (ITransaction transaction = _session.BeginTransaction())
        {
            var result = (int)_session.Save(dbRecord);
            transaction.Commit();
            return GetBySolidId(result);
        }
    }

    public DBModels.NHibernateRecord Update(NHibernateRecord record)
    {
        var objToUpdate = GetBySolidId(record.Id);

        objToUpdate.SolidId = record.SolidId;
        objToUpdate.Name = record.Name;

        using (ITransaction transaction = _session.BeginTransaction())
        {
            _session.Update(objToUpdate);
            transaction.Commit();
            return GetBySolidId(record.Id);
        }
    }

    public void Delete(NHibernateRecord record)
    {
        var objToDelete = _session.Get<DBModels.NHibernateRecord>(record.Id);
        using (ITransaction transaction = _session.BeginTransaction())
        {
            _session.Delete(objToDelete);
            transaction.Commit();
        }

    }

    public DBModels.NHibernateRecord? GetBySolidId(int id)
    {
        var result = _session.Query<DBModels.NHibernateRecord>().FirstOrDefault(x => x.SolidId == id);
        return result;
    }
}
