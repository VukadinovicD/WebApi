using System.ComponentModel.DataAnnotations;
namespace AspNetCoreWebApiTask1.Models;

public class SpecialBookCreationDto
{
    [Required(ErrorMessage = "You should provide a name value.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "You should provide a special editon details value.")]
    public string SpecialEditionDetails { get; set; } = string.Empty;
}