namespace MigrationsEntityFramework_AspNetCore.DBModels;

public class Chat
{
    public int Id { get; set; }
    public int ChatName { get; set; }

    public virtual List<ChatPersonRelation> ChatPersonRelations { get; set; }
}
