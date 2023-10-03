namespace AspNetCoreWebApiTask1.Models;

public class BookstoreDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public ICollection<BookDto> Books { get; set; } = new List<BookDto>();
}
