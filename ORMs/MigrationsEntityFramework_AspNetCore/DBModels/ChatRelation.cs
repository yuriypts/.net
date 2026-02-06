namespace MigrationsEntityFramework_AspNetCore.DBModels;

public class ChatRelation
{
    public int PersonId { get; set; }
    public int PersonChatId { get; set; }

    public virtual Person Person { get; set; }
    public virtual PersonChat PersonChat { get; set; }
}
