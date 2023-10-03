using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreWebApiTask1.Entities;

public class Bookstore
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;
    
    public ICollection<Book> Books { get; set; } = new List<Book>();
    
    public Bookstore(string name)
    {
        Name = name;
    }
}
