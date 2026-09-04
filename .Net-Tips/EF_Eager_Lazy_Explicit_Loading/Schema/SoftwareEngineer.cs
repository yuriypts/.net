
namespace EF_Eager_Lazy_Explicit_Loading.Schema;

public class SoftwareEngineer
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public List<Device> Devices { get; set; } = default!;
}
