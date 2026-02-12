namespace MigrationsEntityFramework_AspNetCore.DBModels;

public class Person
{
    public int Id { get; set; }
    public int Name { get; set; }
    public int SalaryId { get; set; }
    public int DriveCloudId { get; set; }

    public virtual DriveCloud DriveCloud { get; set; }
    public virtual List<ChatPersonRelation> ChatPersonRelations { get; set; }
}
