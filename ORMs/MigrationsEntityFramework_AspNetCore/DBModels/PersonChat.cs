namespace MigrationsEntityFramework_AspNetCore.DBModels;

public class PersonChat
{
    public int Id { get; set; }
    public int ChatName { get; set; }

    public virtual List<ChatRelation> ChatRelations { get; set; }
}
