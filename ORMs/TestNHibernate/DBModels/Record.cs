namespace TestNHibernate.DBModels;

public class Record
{
    public virtual int Id { get; set; }
    public virtual int SolidId { get; set; }
    public virtual string? Name  { get; set; }
}
