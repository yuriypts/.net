namespace MigrationsEntityFramework_AspNetCore.DBModels;

public class ChatPersonRelation
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int ChatId { get; set; }

    public virtual Person Person { get; set; }
    public virtual Chat Chat { get; set; }
}
