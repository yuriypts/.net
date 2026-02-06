namespace MigrationsEntityFramework_AspNetCore.DBModels;

public class DriveCloud
{
    public int Id { get; set; }
    public string Parth { get; set; }
    public byte[] Document { get; set; }
    
    public virtual List<Person> Persons { get; set; }
}
