using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using TestNHibernate.Helpers;
using TestNHibernate.Mappings;
using TestNHibernate.SessionFactory.Interfaces;

namespace TestNHibernate.SessionFactory;

public class NHibernateSessionFactory : INHibernateSessionFactory
{
    public NHibernateSessionFactory(IConfiguration configuration)
    {
        SessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2008.ConnectionString(configuration.GetConnectionString(DatabaseConnections.TestNHibernateConnectionString)))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RecordMap>().Conventions.Add(DefaultLazy.Never(), DefaultCascade.All()))
            .BuildSessionFactory();
    }

    public ISessionFactory SessionFactory { get; private set; }

    public void Dispose()
    {
        if (SessionFactory != null)
        {
            SessionFactory.Dispose();
            SessionFactory = null;
        }
    }
}
