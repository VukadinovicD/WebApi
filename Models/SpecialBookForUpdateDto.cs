using System.ComponentModel.DataAnnotations;
namespace AspNetCoreWebApiTask1.Models;

public class SpecialBookForUpdateDto
{
    public string Name { get; set; } = string.Empty;

    public string SpecialEditionDetails { get; set; } = string.Empty;
}