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

    /// <summary>
    ///     Добавление книги
    /// </summary>
    /// <param name="bookDto">Сущность книги</param>
    /// <returns></returns>
    [HttpPost("book")]
    public async Task<IActionResult> AddBook(BookDto bookDto)
    {
        await _repository.AddBook(bookDto);
        return Ok();
    }

    /// <summary>
    ///     Получить список всех книг
    /// </summary>
    /// <returns></returns>
    [HttpGet("book")]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _repository.GetBooks();
        return Ok(books);
    }

    /// <summary>
    ///     Получение книги по Id
    /// </summary>
    /// <param name="id">дентификатор книги</param>
    /// <returns></returns>
    [HttpGet("bookById")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var books = await _repository.GetBookById(id);
        return Ok(books);
    }

    /// <summary>
    ///     Получение книг по названию
    /// </summary>
    /// <param name="title">Название книги</param>
    /// <returns></returns>
    [HttpGet("bookByTitle")]
    public async Task<IActionResult> GetBookByTitle(string title)
    {
        var books = await _repository.GetBooksByTitle(title);
        return Ok(books);
    }

    /// <summary>
    ///     Получение книг по дате выхода
    /// </summary>
    /// <param name="releaseDate">Дата выхода книги</param>
    /// <returns></returns>
    [HttpGet("bookByReleaseDate")]
    public async Task<IActionResult> GetBookByReleaseDate(DateTime releaseDate)
    {
        var books = await _repository.GetBooksByReleaseDate(releaseDate);
        return Ok(books);
    }

    /// <summary>
    ///     Удалить книгу по Id
    /// </summary>
    /// <param name="id">Идентификатор книги</param>
    /// <returns></returns>
    [HttpDelete("book")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _repository.DeleteBook(id);
        return Ok();
    }
}