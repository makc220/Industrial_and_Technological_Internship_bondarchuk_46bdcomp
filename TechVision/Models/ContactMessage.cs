using System.ComponentModel.DataAnnotations;

namespace TechVision.Models;

public class ContactMessage
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введіть ваше ім'я.")]
    [StringLength(100, ErrorMessage = "Ім'я не може перевищувати 100 символів.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введіть електронну пошту.")]
    [EmailAddress(ErrorMessage = "Введіть коректну електронну пошту.")]
    [StringLength(150, ErrorMessage = "Електронна пошта не може перевищувати 150 символів.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введіть текст повідомлення.")]
    [StringLength(2000, ErrorMessage = "Повідомлення не може перевищувати 2000 символів.")]
    public string Message { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
