using Kaspel.Context;
using Kaspel.DTO;
using Kaspel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kaspel.Controllers;

[ApiController]
public class OrderController : ControllerBase
{
    private readonly KaspelContext _context;

    public OrderController(KaspelContext context)
    {
        _context = context;
    }

    [HttpPost("order")]
    public ActionResult AddOrder(OrderDto orderDto)
    {
        var books = _context.Books.ToList();
        var order = _context.Orders.Add(new Order()
        {
            OrderDate = DateTime.Now
        });
        _context.SaveChanges();
        foreach (var bookId in orderDto.Books)
        {
            if (books.Exists(x => x.Id == bookId))
                _context.OrderBooks.Add(new OrderBook()
                {
                    OrderId = order.Entity.Id,
                    BookId = bookId
                });
            else
            {
                throw new InvalidOperationException($"Не удалось создать заказ. \n Книги с Id: {bookId} не существует");
            }
        }

        _context.SaveChanges();

        return Ok();
    }

    [HttpGet("order")]
    public ActionResult GetOrders() => Ok(_context.Orders.Include(books => books.Books).ToList());
}