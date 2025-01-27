using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEF.Models;

[Table("User")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MinLength(10)]
    [MaxLength(80)]
    [Column("Name", TypeName = "NVARCHAR")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MinLength(20)]
    [MaxLength(200)]
    [Column("Email", TypeName = "VARCHAR")]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MinLength(50)]
    [MaxLength(255)]
    [Column("PasswordHash", TypeName = "VARCHAR")]
    public string PasswordHash { get; set; } = string.Empty;
    [Required]
    [Column("Bio", TypeName = "TEXT")]
    public string Bio { get; set; } = string.Empty;
    [Required]
    [MinLength(60)]
    [MaxLength(2000)]
    [Column("Image", TypeName = "VARCHAR")]
    public string Image { get; set; } = string.Empty;
    [Required]
    [MinLength(3)]
    [MaxLength(80)]
    [Column("Slug", TypeName = "VARCHAR")]
    public string Slug { get; set; } = string.Empty;
}