using AutoMapper;
using AspNetCoreWebApiTask1.Services;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebApiTask1.Models;

namespace AspNetCoreWebApiTask1.Controllers;

[ApiController]
[Route("api/bookstore/{bookstoreId}/book")]
public class BookController : ControllerBase
{
    private readonly IBookstoreServices _bookstoreServices;

    private readonly IMapper _mapper;
    
    public BookController(IMapper mapper, IBookstoreServices bookstoreServices)
    {
        _bookstoreServices = bookstoreServices;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<BookDto>> GetBooksByStoreId(int bookstoreId)
    {
        try
        {
            return Ok(await _bookstoreServices.GetBookByStoreId(bookstoreId));
        }
        catch(KeyNotFoundException k)
        {
            return NotFound(k.Data);
        }
        catch 
        {
            return StatusCode(500, "Intern Internal Server Error ");
        }
    }

    [HttpGet("{bookId}")]
    public async Task<ActionResult<BookDto>> GetBookById(int bookstoreId, int bookId)
    {
        try
        {
            return Ok(await _bookstoreServices.GetBookById(bookstoreId, bookId));
        }
        catch (KeyNotFoundException k)
        {
            return NotFound(k.Data);
        }
        catch 
        {
            return StatusCode(500, "Intern Internal Server Error ");
        }
    }

    [HttpPost]
    public async Task<ActionResult<SpecialBookDto>> CreateBook(int bookstoreId, BookCreationDto book)
    {
        try
        {
            await _bookstoreServices.CreateBook(bookstoreId, book);
            return NoContent();
        }
        catch (KeyNotFoundException k)
        {
            return NotFound(k.Data);
        }
        catch 
        {
            return StatusCode(500, "Intern Internal Server Error ");
        }
    }

    [HttpPost("specialBook")]
    public async Task<ActionResult<SpecialBookDto>> CreateSpecialBook(int bookstoreId, SpecialBookCreationDto book)
    {
        try
        {
            await _bookstoreServices.CreateSpecialBook(bookstoreId, book);
            return NoContent();
        }
        catch (KeyNotFoundException k)
        {
            return NotFound(k.Data);
        }
        catch 
        {
            return StatusCode(500, "Intern Internal Server Error ");
        }
    }

    [HttpDelete("{bookId}")]
    public async Task<ActionResult> DeleteBook(int bookstoreId, int bookId)
    {
        try
        {
            await _bookstoreServices.DeleteBook(bookstoreId, bookId);
            return NoContent();
        }
        catch (KeyNotFoundException k)
        {
            return NotFound(k.Data);
        }
        catch 
        {
            return StatusCode(500, "Intern Internal Server Error ");
        }
    }

    [HttpPut("{bookId}")]
    public async Task<ActionResult> UpdateBook(int bookstoreId, int bookId, BookCreationDto book)
    {
        try
        {
            await _bookstoreServices.UpdateBook(bookstoreId, bookId, book);
            return NoContent();
        }
        catch (KeyNotFoundException k)
        {
            return NotFound(k.Data);
        }
        catch 
        {
            return StatusCode(500, "Intern Internal Server Error ");
        }
    }
   
    [HttpPut("/specialBook/{bookId}")]
    public async Task<ActionResult> UpdateSpecialBook(int bookstoreId, int bookId, SpecialBookForUpdateDto book)
    {
        try
        {
            await _bookstoreServices.UpdateSpecialBook(bookstoreId, bookId, book);
            return NoContent();
        }
        catch (KeyNotFoundException k)
        {
            return NotFound(k.Data);
        }
        catch 
        {
            return StatusCode(500, "Intern Internal Server Error ");
        }
    }
}
