using System.ComponentModel.DataAnnotations;
namespace AspNetCoreWebApiTask1.Models;

public class BookCreationDto
{
    [Required(ErrorMessage = "You should provide a name value.")]
    public string Name { get; set; } = string.Empty;
}
