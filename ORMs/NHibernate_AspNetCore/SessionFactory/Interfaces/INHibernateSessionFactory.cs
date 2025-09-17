using NHibernate;

namespace NHibernate_AspNetCore.SessionFactory.Interfaces;

public interface INHibernateSessionFactory : IDisposable
{
    public ISessionFactory SessionFactory { get; }
}
