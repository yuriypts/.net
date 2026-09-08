namespace EF_Eager_Lazy_Explicit_Loading.DBModels;

public class Device
{
    public int Id { get; set; }
    public string Type { get; set; } = default!;
    public int SoftwareEngineerId { get; set; }
    public virtual SoftwareEngineer SoftwareEngineer { get; set; } = default!;
}
