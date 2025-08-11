using NHibernate;
using TestNHibernate.Repositories.Interfaces;
using TestNHibernate.SessionFactory.Interfaces;
using TestNHibernate.Shema;

namespace TestNHibernate.Repositories;

public class RecordRepository : IRecordRepository
{
    private readonly NHibernate.ISession _session;

    public RecordRepository(INHibernateSessionFactory nHibernateSessionFactory)
    {
        _session = nHibernateSessionFactory.SessionFactory.OpenSession();
    }

    public DBModels.Record Create(Record record)
    {
        DBModels.Record dbRecord = new DBModels.Record
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

    public DBModels.Record Update(Record record)
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

    public void Delete(Record record)
    {
        var objToDelete = _session.Get<DBModels.Record>(record.Id);
        using (ITransaction transaction = _session.BeginTransaction())
        {
            _session.Delete(objToDelete);
            transaction.Commit();
        }

    }

    public DBModels.Record? GetBySolidId(int id)
    {
        var result = _session.Query<DBModels.Record>().FirstOrDefault(x => x.SolidId == id);
        return result;
    }
}
