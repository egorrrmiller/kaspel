using System.Text.Json.Serialization;

namespace DataBase.DTO;

public record BookDto(
    [property: JsonIgnore] int Id, 
    string Title, string? Description, DateTime ReleaseDate);
