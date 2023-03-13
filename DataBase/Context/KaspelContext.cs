using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Context;

public class KaspelContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderBook> OrderBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // SQLite использовал т.к не установлен MSSQL на ноутбук.
        // Т.к используется EF, то это легко меняется
        optionsBuilder.UseSqlite("Data Source = kaspel.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(o =>
        {
            o
                .HasMany(a => a.Books)
                .WithMany(b => b.Orders)
                .UsingEntity<OrderBook>();
        });
    }
}