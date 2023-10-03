using AspNetCoreWebApiTask1.Models;


namespace AspNetCoreWebApiTask1.Services;

public interface IBookstoreServices
{
        Task<BookDto> GetBookById(int bookId, int bookstoreId);

        Task<IEnumerable<BookDto>> GetBookByStoreId(int bookstoreId);

        Task<BookDto> CreateBook(int bookstoreId, BookCreationDto book);

        Task DeleteBook(int bookstoreId, int bookId);

        Task<BookDto> UpdateBook(int bookstoreId, int bookId, BookCreationDto book);

        Task<IEnumerable<BookstoreDto>> GetAllBookstores();
        
        Task<BookstoreDto> GetBookstoreById(int bookstoreId);

        Task<BookDto> CreateSpecialBook(int bookstoreId, SpecialBookCreationDto book);
        
        Task<SpecialBookDto> UpdateSpecialBook(int bookstoreId, int bookId, SpecialBookForUpdateDto book);

}
