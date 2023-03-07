using DataBase.Repository;
using Kaspel.Context;
using Kaspel.DTO;
using Kaspel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kaspel.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    private readonly IKaspelRepository _repository;

    public BookController(IKaspelRepository repository)
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
}