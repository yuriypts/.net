namespace EF_Eager_Lazy_Explicit_Loading.DBModels;

public class SoftwareEngineer
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public virtual IEnumerable<Device> Devices { get; set; } = default!;
}
