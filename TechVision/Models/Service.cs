using System.ComponentModel.DataAnnotations;

namespace TechVision.Models;

public class Service
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введіть назву послуги.")]
    [StringLength(100, ErrorMessage = "Назва послуги не може перевищувати 100 символів.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введіть опис послуги.")]
    [StringLength(1000, ErrorMessage = "Опис послуги не може перевищувати 1000 символів.")]
    public string Description { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Назва іконки не може перевищувати 100 символів.")]
    public string Icon { get; set; } = string.Empty;
}
