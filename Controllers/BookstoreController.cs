using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebApiTask1.Services;
using AspNetCoreWebApiTask1.Models;
using AutoMapper;

namespace AspNetCoreWebApiTask1.Controllers;

[ApiController]
[Route("api/bookstore")]
public class BookstoreController : ControllerBase
{
    private readonly IBookstoreServices _bookstoreServices;
    private readonly IMapper _mapper;

    public BookstoreController(IBookstoreServices bookstoreServices, IMapper mapper)
    {
        _bookstoreServices = bookstoreServices;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookstoreDto>>> AllBookstores()
    {
        try{
        return Ok( await _bookstoreServices.GetAllBookstores());
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

    [HttpGet("{bookstoreId}")]
    public async Task<ActionResult<BookstoreDto>> BookstoreById(int bookstoreId)
    {
        try
        {
        return Ok( await _bookstoreServices.GetBookstoreById(bookstoreId));
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
