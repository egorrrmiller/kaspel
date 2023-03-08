namespace DataBase.Models;
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime ReleaseDate { get; set; }

    
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public List<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
    
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public List<Order> Orders { get; set; } = new List<Order>();
}