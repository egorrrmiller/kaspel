namespace DataBase.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    

    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public List<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
    
    
    public List<Book> Books { get; set; } = new List<Book>();
    
}