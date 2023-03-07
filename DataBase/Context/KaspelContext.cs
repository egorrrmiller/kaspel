using Kaspel.Models;
using Microsoft.EntityFrameworkCore;

namespace Kaspel.Context;

public class KaspelContext : DbContext
{
    public KaspelContext(DbContextOptions<KaspelContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderBook> OrderBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(o =>
        {
            //o.HasKey(key => key.Id);
            //o.HasIndex(name => name.Id).IsUnique();
            o
                .HasMany(a => a.Books)
                .WithMany(b => b.Orders)
                .UsingEntity<OrderBook>(
                    book => book
                        .HasOne(b => b.Book)
                        .WithMany(o => o.OrderBooks)
                        .HasForeignKey(id => id.BookId),
                    order => order
                        .HasOne(o => o.Order)
                        .WithMany(b => b.OrderBooks)
                        .HasForeignKey(id => id.OrderId));
        });

        /*modelBuilder.Entity<Book>(book =>
        {
            book.HasData(new Book()
            {
                Id = 1,
                Title = "titele 1",
                ReleaseDate = DateTime.Now
            }, new Book()
            {
                Id = 2,
                Title = "titele 2",
                ReleaseDate = DateTime.Now
            }, new Book()
            {
                Id = 3,
                Title = "titele 3",
                ReleaseDate = DateTime.Now
            });
        });

        modelBuilder.Entity<Order>(o =>
        {
            o.HasData(new Order()
            {
                Id = 1,
                OrderDate = DateTime.Now
            },new Order()
            {
                Id = 2,
                OrderDate = DateTime.Now
            },new Order()
            {
                Id = 3,
                OrderDate = DateTime.Now
            });
        });

        modelBuilder.Entity<OrderBook>(b =>
        {
            b.HasData(new OrderBook()
            {
                BookId = 1,
                OrderId = 1
            }, new OrderBook()
            {
                BookId = 2,
                OrderId = 1
            }, new OrderBook()
            {
                BookId = 3,
                OrderId = 1
            }, new OrderBook()
            {
                BookId = 1,
                OrderId = 2
            }, new OrderBook()
            {
                BookId = 2,
                OrderId = 2
            }, new OrderBook()
            {
                BookId = 3,
                OrderId = 2
            });
        });*/
    }
}