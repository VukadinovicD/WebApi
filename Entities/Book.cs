using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreWebApiTask1.Entities;

public class Book : IInventory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [ForeignKey("BookstoreId")]
    public Bookstore? Bookstore { get; set; }
    
    public int BookstoreId { get; set; }

    public Book(string name)
    {
        Name = name;
    }

    public virtual string GetBookDetails()
    {
        return Name;
    }

    public int CalculateInventoryValue()
    {
        return Id * 10;
    }
}
