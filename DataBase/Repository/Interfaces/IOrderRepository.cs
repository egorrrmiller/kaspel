using DataBase.DTO;
using DataBase.Models;

namespace DataBase.Repository.Interfaces;

public interface IOrderRepository
{
    /// <summary>
    /// Получить список всех заказов
    /// </summary>
    /// <returns></returns>
    Task<List<Order>> GetOrders();
    
    /// <summary>
    /// Получить заказ по Id
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <returns></returns>
    Task<Order> GetOrderById(int id);
    
    /// <summary>
    /// Добавить заказ
    /// </summary>
    /// <param name="bookDto"></param>
    /// <returns></returns>
    Task AddOrder(OrderDto bookDto);
    
    /// <summary>
    /// Удалить заказ по Id
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <returns></returns>
    Task DeleteOrder(int id);
}