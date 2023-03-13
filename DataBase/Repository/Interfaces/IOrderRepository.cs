using DataBase.DTO;

namespace DataBase.Repository.Interfaces;

public interface IOrderRepository
{
    /// <summary>
    ///     Добавить заказ
    /// </summary>
    /// <param name="bookDto"></param>
    /// <returns></returns>
    Task AddOrder(OrderDto bookDto);

    /// <summary>
    ///     Удалить заказ по Id
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <returns></returns>
    Task DeleteOrder(int id);

    /// <summary>
    ///     Получить список всех заказов
    /// </summary>
    /// <returns></returns>
    Task<List<OrderDetailDto>> GetOrders();

    /// <summary>
    ///     Получить заказ по Id
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <returns></returns>
    Task<OrderDetailDto> GetOrderById(int id);

    /// <summary>
    ///     Получить заказ по дате создания
    /// </summary>
    /// <param name="orderDate">Время создания заказа</param>
    /// <returns></returns>
    Task<List<OrderDetailDto>> GetOrderByOrderDate(DateTime orderDate);
}