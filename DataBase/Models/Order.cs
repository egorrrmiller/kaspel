using Newtonsoft.Json;

namespace DataBase.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }

    [JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public List<OrderBook> OrderBooks { get; set; } = new();

    public List<Book> Books { get; set; } = new();
}