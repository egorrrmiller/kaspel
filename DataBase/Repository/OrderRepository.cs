using DataBase.Context;
using DataBase.DTO;
using DataBase.Models;
using DataBase.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly KaspelContext _context;

    public OrderRepository(KaspelContext context)
    {
        _context = context;
    }

    public async Task AddOrder(OrderDto orderDto)
    {
        var books = await _context.Books.ToListAsync();

        // смотрим есть ли книги в базе данных
        if (orderDto.Books.Any(bookId => !books.Exists(x => x.Id == bookId)))
            throw new InvalidOperationException();

        // создаем заказ
        var order = await _context.Orders.AddAsync(new Order { OrderDate = DateTime.Now });
        await _context.SaveChangesAsync();

        // и добавляем данные о книгах и заказе
        await _context.OrderBooks.AddRangeAsync(
            orderDto.Books.Select(bookId => new OrderBook { OrderId = order.Entity.Id, BookId = bookId }));
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order is null)
            throw new InvalidOperationException("Заказа с таким Id не существует");

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task<List<OrderDetailDto>> GetOrders()
    {
        var orders = await _context.Orders.Include(book => book.Books).ToListAsync();

        return orders.Select(order => new OrderDetailDto(order.Id, order.OrderDate, order.Books)).ToList();
    }

    public async Task<OrderDetailDto> GetOrderById(int id)
    {
        var orderById = await _context.Orders
            .Include(book => book.Books)
            .FirstOrDefaultAsync(order => order.Id == id);

        if (orderById is null)
            throw new NullReferenceException("Заказа с таким Id не существует");

        return new OrderDetailDto(orderById.Id, orderById.OrderDate, orderById.Books);
    }

    public async Task<List<OrderDetailDto>> GetOrderByOrderDate(DateTime orderDate)
    {
        // теоретически может быть создано много заказов в одного время, поэтому Where
        var orderById = _context.Orders
            .Include(book => book.Books)
            .Where(order => order.OrderDate == orderDate)
            .ToList();

        if (orderById is null)
            throw new NullReferenceException("Заказа с таким Id не существует");

        return orderById.Select(order => new OrderDetailDto(order.Id, order.OrderDate, order.Books)).ToList();
    }
}