using AspNetCoreWebApiTask1.Models;
using AutoMapper;


namespace AspNetCoreWebApiTask1.Services;

public class BookstoreServices : IBookstoreServices
{
    private readonly IBookstoreRepository _bookstoreRepository;
    private readonly IMapper _mapper;
    public BookstoreServices(IBookstoreRepository bookstorerepository, IMapper mapper)
    {
        _bookstoreRepository = bookstorerepository ?? throw new ArgumentNullException(nameof(bookstorerepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<BookstoreDto> GetBookstoreById(int bookstoreId)
    {
        var bookstoreEntity = await _bookstoreRepository.GetBookstore(bookstoreId);
        var bookstore = _mapper.Map<BookstoreDto>(bookstoreEntity);
        DoesBookstoreExsit(bookstore);
        return bookstore;
    }

    public async Task<BookDto> GetBookById(int bookstoreId, int bookId)
    {
        var bookstoreEntity = await _bookstoreRepository.GetBookstore(bookstoreId);
        var bookstore = _mapper.Map<BookstoreDto>(bookstoreEntity);
        DoesBookstoreExsit(bookstore);

        var bookEntity = await _bookstoreRepository.GetBookById(bookstoreId, bookId);
        var book = _mapper.Map<BookDto>(bookEntity);
        DoesBookExsit(book);

        return _mapper.Map<BookDto>(book);
    }

    public async Task<IEnumerable<BookDto>> GetBookByStoreId(int bookstoreId)
    {
        var bookstoreEntity = await _bookstoreRepository.GetBookstore(bookstoreId);
        var bookstore = _mapper.Map<BookstoreDto>(bookstoreEntity);
        DoesBookstoreExsit(bookstore);

        var books = await _bookstoreRepository.GetBooksByBookstoreId(bookstoreId);
        if(books == null)
        {
            throw new KeyNotFoundException(nameof(bookstoreId));
        }
        return _mapper.Map<IEnumerable<BookDto>>(books);
    }

    public async Task<BookDto> CreateBook(int bookstoreId, BookCreationDto book)
    {
        var bookstoreEntity = await _bookstoreRepository.GetBookstore(bookstoreId);
        var bookstore = _mapper.Map<BookstoreDto>(bookstoreEntity);
        DoesBookstoreExsit(bookstore);

        var newEntity = _mapper.Map<Entities.Book>(book);
        newEntity.BookstoreId = bookstoreId;
        await _bookstoreRepository.AddBook(newEntity);
        await _bookstoreRepository.SaveChangesAsync();

        return _mapper.Map<Models.BookDto>(newEntity);
    }

    public async Task<BookDto> CreateSpecialBook(int bookstoreId, SpecialBookCreationDto book)
    {
        var bookstoreEntity = await _bookstoreRepository.GetBookstore(bookstoreId);
        var bookstore = _mapper.Map<BookstoreDto>(bookstoreEntity);
        DoesBookstoreExsit(bookstore);

        var newEntity = _mapper.Map<Entities.SpecialBook>(book);
        newEntity.BookstoreId = bookstoreId;
        await _bookstoreRepository.AddSpecialBook(newEntity);
        await _bookstoreRepository.SaveChangesAsync();

        return _mapper.Map<Models.SpecialBookDto>(newEntity);
    }

    public async Task DeleteBook(int bookstoreId, int bookId)
    {
        var bookstoreEntity = await _bookstoreRepository.GetBookstore(bookstoreId);
        var bookstore = _mapper.Map<BookstoreDto>(bookstoreEntity);
        DoesBookstoreExsit(bookstore);

        var bookEntity = await _bookstoreRepository.GetBookById(bookstoreId, bookId);
        var book = _mapper.Map<BookDto>(bookEntity);
        DoesBookExsit(book);
        
        _bookstoreRepository.Remove(bookEntity!);
        await _bookstoreRepository.SaveChangesAsync();
    }

    public async Task<BookDto> UpdateBook(int bookstoreId, int bookId, BookCreationDto book)
    {
        var bookstoreEntity = await _bookstoreRepository.GetBookstore(bookstoreId);
        var bookstore = _mapper.Map<BookstoreDto>(bookstoreEntity);
        DoesBookstoreExsit(bookstore);

        var updateBookEntity = await _bookstoreRepository.GetBookById(bookstoreId, bookId);
        var updateBook = _mapper.Map<BookDto>(updateBookEntity);
        DoesBookExsit(updateBook);

        updateBookEntity!.Name = book.Name;
        await _bookstoreRepository.SaveChangesAsync();
        return _mapper.Map<BookDto>(updateBookEntity);
    }

    public async Task<SpecialBookDto> UpdateSpecialBook(int bookstoreId, int bookId, SpecialBookForUpdateDto book)
    {
        var bookstoreEntity = await _bookstoreRepository.GetBookstore(bookstoreId);
        var bookstore = _mapper.Map<BookstoreDto>(bookstoreEntity);
        DoesBookstoreExsit(bookstore);     

        var updateBookEntity = (  await _bookstoreRepository.GetBookById(bookstoreId, bookId) as Entities.SpecialBook);
        var updateBook = _mapper.Map<SpecialBookDto>(updateBookEntity);
        DoesBookExsit(updateBook);  

       _mapper.Map(book, updateBookEntity);
     
        await _bookstoreRepository.SaveChangesAsync();

        return _mapper.Map<SpecialBookDto>(updateBookEntity);
    }

    public async Task<IEnumerable<BookstoreDto>> GetAllBookstores()
    {
        var bookstore = await _bookstoreRepository.GetAllBookstores();
        return _mapper.Map<IEnumerable<BookstoreDto>>(bookstore);
    }

        private void DoesBookstoreExsit(BookstoreDto bookstore)
    {
            if(bookstore == null)
        {
            throw new KeyNotFoundException(nameof(bookstore.Id));

        }
    }

    private void DoesBookExsit(BookDto book)
    {
            if(book == null)
        {
            throw new KeyNotFoundException(nameof(book.Id));
        }
    }
}
