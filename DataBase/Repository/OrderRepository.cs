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

    public async Task<List<Order>> GetOrders()
    {
        return await _context.Orders.Include(book => book.Books).ToListAsync();
    }

    public async Task<Order> GetOrderById(int id)
    {
        var orderById = await _context.Orders
            .Include(book => book.Books)
            .FirstOrDefaultAsync(order => order.Id == id);
        if (orderById is null)
            throw new NullReferenceException("Заказа с таким Id не существует");

        return orderById;
    }

    public async Task<List<Order>> GetOrderByOrderDate(DateTime orderDate)
    {
        // теоретически может быть создано много заказов в одного время, поэтому Where
        var orderById = _context.Orders
            .Include(book => book.Books)
            .Where(order => order.OrderDate == orderDate)
            .ToList();
        if (orderById is null)
            throw new NullReferenceException("Заказа с таким Id не существует");

        return orderById;
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
        foreach (var bookId in orderDto.Books)
            await _context.OrderBooks.AddAsync(new OrderBook { OrderId = order.Entity.Id, BookId = bookId });
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
}