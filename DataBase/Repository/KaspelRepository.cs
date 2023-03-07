using Kaspel.Context;
using Kaspel.DTO;
using Kaspel.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repository;

public class KaspelRepository : IKaspelRepository
{
    private readonly KaspelContext _context;

    public KaspelRepository(KaspelContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> GetBookById(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
        if (book is null)
            throw new NullReferenceException($"Книги с Id:{id} не существует");

        return book;
    }

    public async Task AddBook(BookDto bookDto)
    {
        await _context.Books.AddAsync(new Book()
        {
            Title = bookDto.Title,
            Description = bookDto.Description,
            ReleaseDate = bookDto.ReleaseDate
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBook(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
        if (book is null)
            throw new NullReferenceException($"Книги с Id:{id} не существует");

        _context.Books.Remove(book);
    }

    public async Task<List<Order>> GetOrders()
    {
        return await _context.Orders.ToListAsync();
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
            if (books.Exists(x => x.Id == bookId))
                await _context.OrderBooks.AddAsync(new OrderBook()
                {
                    OrderId = order.Entity.Id,
                    BookId = bookId
                });
            else
            {
                throw new InvalidOperationException($"Не удалось создать заказ. \n Книги с Id: {bookId} не существует");
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrder(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);
        if (order is null)
            throw new NullReferenceException($"Заказа с Id:{id} не существует");

        _context.Orders.Remove(order);
    }
}