namespace eCommerce1.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public decimal TotalAmount { get; set; }
}

public class OrderItem
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}