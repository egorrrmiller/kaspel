using DataBase.DTO;
using DataBase.Repository;
using DataBase.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kaspel.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRepository _repository;

    public BookController(IBookRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("book")]
    public async Task<IActionResult> AddBook(BookDto bookDto)
    {
        await _repository.AddBook(bookDto);
        return Ok();
    }
    
    [HttpGet("book")]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _repository.GetBooks();
        return Ok(books);
    }
    
    [HttpDelete("book")]
    public async Task<IActionResult> DeleteBook(int id)
    { 
        await _repository.DeleteBook(id);
        return Ok();
    }
}