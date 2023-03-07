using Kaspel.DTO;
using Kaspel.Models;

namespace DataBase.Repository;

public interface IKaspelRepository
{
    Task<List<Book>> GetBooks();
    Task<Book> GetBookById(int id);
    Task AddBook(BookDto bookDto);
    Task DeleteBook(int id);
    
    Task<List<Order>> GetOrders();
    Task<Order> GetOrderById(int id);
    Task AddOrder(OrderDto bookDto);
    Task DeleteOrder(int id);

}