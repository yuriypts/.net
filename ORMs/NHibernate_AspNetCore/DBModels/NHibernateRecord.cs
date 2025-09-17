namespace NHibernate_AspNetCore.DBModels;

public class NHibernateRecord
{
    public virtual int Id { get; set; }
    public virtual int SolidId { get; set; }
    public virtual string? Name  { get; set; }
}
