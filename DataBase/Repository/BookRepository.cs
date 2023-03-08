using DataBase.Context;
using DataBase.DTO;
using DataBase.Models;
using DataBase.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repository;

public class BookRepository : IBookRepository
{
    private readonly KaspelContext _context;

    public BookRepository(KaspelContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> GetBookById(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is null)
            throw new NullReferenceException();

        return book;
    }

    public async Task<List<Book>> GetBooksByTitle(string title)
    {
        var book = _context.Books.Where(book => book.Title == title).ToList();

        return book;
    }

    public async Task<List<Book>> GetBooksByReleaseDate(DateTime releaseDate)
    {
        var book = _context.Books.Where(book => book.ReleaseDate == releaseDate).ToList();

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
}