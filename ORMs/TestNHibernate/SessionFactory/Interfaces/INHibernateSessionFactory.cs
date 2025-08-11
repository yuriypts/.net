using NHibernate;

namespace TestNHibernate.SessionFactory.Interfaces;

public interface INHibernateSessionFactory : IDisposable
{
    public ISessionFactory SessionFactory { get; }
}
