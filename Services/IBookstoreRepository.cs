using AspNetCoreWebApiTask1.Entities;

namespace AspNetCoreWebApiTask1.Services;

public interface IBookstoreRepository
{
    Task<IEnumerable<Bookstore>> GetAllBookstores(); 
    Task<Bookstore?> GetBookstore(int bookstoreId); 
    Task<IEnumerable<Book>> GetBooksByBookstoreId(int bookstoreId); 
    Task<Book?> GetBookById(int bookstoreId, int bookId);
    Task AddBook(Book book);
    void Remove(Book book); 
    Task<bool> SaveChangesAsync();
    Task AddSpecialBook(SpecialBook book);
}
