using DataBase.DTO;
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
    
    [HttpGet("bookById")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var books = await _repository.GetBookById(id);
        return Ok(books);
    }
    
    [HttpGet("bookByTitle")]
    public async Task<IActionResult> GetBookByTitle(string title)
    {
        var books = await _repository.GetBooksByTitle(title);
        return Ok(books);
    }
    
    [HttpGet("bookByReleaseDate")]
    public async Task<IActionResult> GetBookByReleaseDate(DateTime releaseDate)
    {
        var books = await _repository.GetBooksByReleaseDate(releaseDate);
        return Ok(books);
    }
    
    [HttpDelete("book")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _repository.DeleteBook(id);
        return Ok();
    }
}