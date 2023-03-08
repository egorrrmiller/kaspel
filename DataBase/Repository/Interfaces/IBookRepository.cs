using DataBase.DTO;
using DataBase.Models;

namespace DataBase.Repository.Interfaces;

public interface IBookRepository
{
    /// <summary>
    /// Получить список книг
    /// </summary>
    /// <returns></returns>
    Task<List<Book>> GetBooks();
    Task<Book> GetBookById(int id);
    
    /// <summary>
    /// Добавить книгу
    /// </summary>
    /// <param name="bookDto"></param>
    /// <returns></returns>
    Task AddBook(BookDto bookDto);
    
    /// <summary>
    /// Удалить книгу по Id
    /// </summary>
    /// <param name="id">Идентификатор книги</param>
    /// <returns></returns>
    Task DeleteBook(int id);   
}