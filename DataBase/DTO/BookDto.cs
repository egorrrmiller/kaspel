using System.Text.Json.Serialization;

namespace DataBase.DTO;

public class BookDto
{
    [JsonIgnore] public int Id { get; set; }

    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime ReleaseDate { get; set; }
}