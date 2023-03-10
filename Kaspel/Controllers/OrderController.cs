using DataBase.DTO;
using DataBase.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kaspel.Controllers;

[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _repository;

    public OrderController(IOrderRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    ///     Добавить заказ
    /// </summary>
    /// <param name="orderDto">Тело заказа</param>
    /// <returns></returns>
    [HttpPost("order")]
    public async Task<IActionResult> AddOrder(OrderDto orderDto)
    {
        await _repository.AddOrder(orderDto);

        return Ok();
    }

    /// <summary>
    ///     Получить список всех заказов
    /// </summary>
    /// <returns>Список всех заказов</returns>
    [HttpGet("order")]
    public async Task<IActionResult> GetOrders()
    {
        return Ok(await _repository.GetOrders());
    }

    /// <summary>
    ///     Получить заказ по Id
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// >
    /// <returns></returns>
    [HttpGet("orderById")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        return Ok(await _repository.GetOrderById(id));
    }

    /// <summary>
    ///     Получить заказ по дате создания
    /// </summary>
    /// <param name="orderDate">Дата создания заказа</param>
    /// >
    /// <returns></returns>
    [HttpGet("orderByOrderDate")]
    public async Task<IActionResult> GetOrderByOrderDate(DateTime orderDate)
    {
        return Ok(await _repository.GetOrderByOrderDate(orderDate));
    }

    /// <summary>
    ///     Удалить заказ по Id
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <returns></returns>
    [HttpDelete("order")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        await _repository.DeleteOrder(id);

        return Ok();
    }
}