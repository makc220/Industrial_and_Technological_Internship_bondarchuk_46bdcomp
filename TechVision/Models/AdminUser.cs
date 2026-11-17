using System.ComponentModel.DataAnnotations;

namespace TechVision.Models;

public class AdminUser
{
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public byte[]? AvatarImage { get; set; }

    [StringLength(50)]
    public string? AvatarContentType { get; set; }
}
