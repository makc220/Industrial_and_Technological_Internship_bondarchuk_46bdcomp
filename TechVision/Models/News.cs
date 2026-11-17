using System.ComponentModel.DataAnnotations;

namespace TechVision.Models;

public class News
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введіть заголовок новини.")]
    [StringLength(150, ErrorMessage = "Заголовок новини не може перевищувати 150 символів.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введіть текст новини.")]
    [StringLength(2000, ErrorMessage = "Текст новини не може перевищувати 2000 символів.")]
    public string Content { get; set; } = string.Empty;
    [StringLength(100, ErrorMessage = "Назва іконки не може перевищувати 100 символів.")]
    public string Icon { get; set; } = string.Empty;
    public DateTime PublishedAt { get; set; } = DateTime.Now;
}
