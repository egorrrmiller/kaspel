using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Kaspel.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    

    [JsonIgnore]
    public List<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
    
    
    public List<Book> Books { get; set; } = new List<Book>();
    
}