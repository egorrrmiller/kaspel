using DataBase.DTO;

namespace DataBase.Repository.Interfaces;

public interface IBookRepository
{
    /// <summary>
    ///     Добавить книгу
    /// </summary>
    /// <param name="bookDto"></param>
    /// <returns></returns>
    Task AddBook(BookDto bookDto);

    /// <summary>
    ///     Удалить книгу по Id
    /// </summary>
    /// <param name="id">Идентификатор книги</param>
    /// <returns></returns>
    Task DeleteBook(int id);

    /// <summary>
    ///     Получить список книг
    /// </summary>
    /// <returns></returns>
    Task<List<BookDto>> GetBooks();

    /// <summary>
    ///     Получение книги по Id
    /// </summary>
    /// <param name="id">Идентификатор книги</param>
    /// <returns></returns>
    Task<BookDto> GetBookById(int id);

    /// <summary>
    ///     Получение книги по названию
    /// </summary>
    /// <param name="title">Название книги</param>
    /// <returns></returns>
    Task<List<BookDto>> GetBooksByTitle(string title);

    /// <summary>
    ///     Получение книги по дате выхода
    /// </summary>
    /// <param name="releaseDate">Дата выхода книги</param>
    /// <returns></returns>
    Task<List<BookDto>> GetBooksByReleaseDate(DateTime releaseDate);
}