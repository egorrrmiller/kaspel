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
        var orderById = await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);
        if (orderById is null)
            throw new NullReferenceException($"Заказа с Id:{id} не существует");

        return orderById;
    }

    public async Task AddOrder(OrderDto orderDto)
    {
        var books = await _context.Books.ToListAsync();
        var order = await _context.Orders.AddAsync(new Order()
        {
            OrderDate = DateTime.Now
        });
        
        await _context.SaveChangesAsync();

        foreach (var bookId in orderDto.Books)
        {
            if (!books.Exists(x => x.Id == bookId))
            {
                await DeleteOrder(order.Entity.Id);
                throw new InvalidOperationException($"Не удалось создать заказ. \n Книги с Id: {bookId} не существует");
            }
            
            await _context.OrderBooks.AddAsync(new OrderBook()
            {
                OrderId = order.Entity.Id,
                BookId = bookId
            });
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrder(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);
        if (order is null)
            throw new InvalidOperationException($"Заказа с Id:{id} не существует");

        _context.Orders.Remove(order);
    }
}