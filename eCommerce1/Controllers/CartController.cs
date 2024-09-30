using eCommerce1.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce1.Controllers;

public class CartController : Controller
{
    public static Cart cart = new() { Items = new List<CartItem>() };

    public IActionResult AddProduct(int productId)
    {
        var product = ProductController.products.Find(p => p.Id == productId);
        if (product != null)
        {
            var existingItem = cart.Items.Find(item => item.Product.Id == productId);
            if (existingItem != null)
                existingItem.Quantity++;
            else
                cart.Items.Add(new CartItem { Product = product, Quantity = 1 });

            cart.TotalAmount += product.Price;
        }

        return View(cart);
    }

    public IActionResult Edit()
    {
        return View(cart);
    }
}