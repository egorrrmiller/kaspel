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

    public async Task AddBook(BookDto bookDto)
    {
        await _context.Books.AddAsync(new Book
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
            throw new NullReferenceException("Книги с таким Id не существует");

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public async Task<List<BookDto>> GetBooks()
    {
        var books = await _context.Books.ToListAsync();

        return books.Select(book => new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            ReleaseDate = book.ReleaseDate
        }).ToList();
    }

    public async Task<BookDto> GetBookById(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is null)
            throw new NullReferenceException("Книги с таким Id не существует");

        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            ReleaseDate = book.ReleaseDate
        };
    }

    public async Task<List<BookDto>> GetBooksByTitle(string title)
    {
        var books = _context.Books.Where(book => book.Title == title).ToList();

        return books.Select(book => new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            ReleaseDate = book.ReleaseDate
        }).ToList();
    }

    public async Task<List<BookDto>> GetBooksByReleaseDate(DateTime releaseDate)
    {
        var books = _context.Books.Where(book => book.ReleaseDate == releaseDate).ToList();

        return books.Select(book => new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            ReleaseDate = book.ReleaseDate
        }).ToList();
        ;
    }
}