using Newtonsoft.Json;

namespace DataBase.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public List<Book> Books { get; set; }

    [JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public ICollection<OrderBook> OrderBooks { get; set; }
}