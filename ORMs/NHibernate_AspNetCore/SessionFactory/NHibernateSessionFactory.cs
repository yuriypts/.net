using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate_AspNetCore.Helpers;
using NHibernate_AspNetCore.Mappings;
using NHibernate_AspNetCore.SessionFactory.Interfaces;

namespace NHibernate_AspNetCore.SessionFactory;

public class NHibernateSessionFactory : INHibernateSessionFactory
{
    public NHibernateSessionFactory(IConfiguration configuration)
    {
        SessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2008.ConnectionString(configuration.GetConnectionString(DatabaseConnections.NHibernateConnectionString)))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateRecordMap>().Conventions.Add(DefaultLazy.Never(), DefaultCascade.All()))
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
