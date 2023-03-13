using System.Text.Json.Serialization;
using DataBase.Models;

namespace DataBase.DTO;

public class OrderDetailDto
{
    [JsonIgnore] public int? Id { get; set; }

    [JsonIgnore] public DateTime? OrderDate { get; set; }

    [JsonIgnore] public List<Book>? Books { get; set; }
}