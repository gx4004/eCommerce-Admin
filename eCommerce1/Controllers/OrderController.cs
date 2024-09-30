using eCommerce1.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce1.Controllers;

public class OrderController : Controller
{
    private static readonly List<Order> orders = new();

    public IActionResult Create()
    {
        if (CartController.cart.Items.Count == 0) return RedirectToAction("List", "Product");

        var newOrder = new Order
        {
            Id = orders.Count + 1,
            OrderItems = new List<OrderItem>(),
            Status = "Processing",
            TotalAmount = CartController.cart.TotalAmount
        };

        foreach (var item in CartController.cart.Items)
            newOrder.OrderItems.Add(new OrderItem { Product = item.Product, Quantity = item.Quantity });

        orders.Add(newOrder);

        CartController.cart.Items.Clear();
        CartController.cart.TotalAmount = 0;

        return RedirectToAction("Details", new { orderId = newOrder.Id });
    }

    public IActionResult Details(int orderId)
    {
        var order = orders.Find(o => o.Id == orderId);
        if (order == null) return NotFound();
        return View(order);
    }
}