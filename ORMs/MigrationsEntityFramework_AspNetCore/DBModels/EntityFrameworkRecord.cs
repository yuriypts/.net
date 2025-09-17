using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MigrationsEntityFramework_AspNetCore.DBModels;

// DataAnnotations
// Apply the Index attribute to the class, not the property, and specify the property name(s)
// [Index(nameof(SolidId), IsUnique = true)]
public class EntityFrameworkRecord
{
    // Primary Key
    //[Key]
    //[Required]
    public int Id { get; set; }

    // Unique Key
    //[Required]
    public int SolidId { get; set; }

    //[StringLength(100)]
    public string? Name { get; set; }
}
