namespace eCommerce1.Models;

public class Cart
{
    public int Id { get; set; }
    public List<CartItem> Items { get; set; }
    public decimal TotalAmount { get; set; }
}

public class CartItem
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}