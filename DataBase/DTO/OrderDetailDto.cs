using DataBase.Models;

namespace DataBase.DTO;

public record OrderDetailDto(int Id, DateTime OrderDate, List<Book> Books);