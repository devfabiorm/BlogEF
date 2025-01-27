using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEF.Models;

[Table("Role")]
public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MinLength(20)]
    [MaxLength(80)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MinLength(3)]
    [MaxLength(80)]
    public string Slug { get; set; } = string.Empty;
}