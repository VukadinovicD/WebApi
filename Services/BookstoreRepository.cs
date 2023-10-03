using AspNetCoreWebApiTask1.Entities;
using AspNetCoreWebApiTask1.DBContext;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApiTask1.Services;

public class BookstoreRepository : IBookstoreRepository
{
    private readonly BookstoreContext _context;
    public BookstoreRepository(BookstoreContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Bookstore>> GetAllBookstores()
    {
        return await _context.Bookstore.OrderBy(a => a.Name).ToListAsync();
    }

    public async  Task<IEnumerable<Book>> GetBooksByBookstoreId(int bookstoreId)
    {
        return await _context.Book.Where(a => a.BookstoreId == bookstoreId).ToListAsync();
    }

    public async Task<Bookstore?> GetBookstore(int bookstoreId)
    {
        return await _context.Bookstore.Where(a => a.Id == bookstoreId).FirstOrDefaultAsync();
    }

    public async Task<Book?> GetBookById(int bookstoreId, int bookId)
    {
        return await _context.Book.Where(a => a.Id == bookId && a.BookstoreId == bookstoreId).FirstOrDefaultAsync();
    }

    public async Task AddBook(Book book)
    {
        var bookstore = await GetBookstore(book.BookstoreId);
        if(bookstore != null)
        {
            _context.Book.Add(book);
        }
        else
        {
            throw new Exception();
        }
    }

        public async Task AddSpecialBook(SpecialBook book)
    {
        var bookstore = await GetBookstore(book.BookstoreId);
        if(bookstore != null)
        {
            _context.Book.Add(book);
        }
        else
        {
            throw new Exception();
        }
    }

    public void Remove(Book book)
    {
        _context.Book.Remove(book);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}
