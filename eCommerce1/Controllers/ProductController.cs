using eCommerce1.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce1.Controllers;

public class ProductController : Controller
{
    // Shared static product list
    public static List<Product> products = new();

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        product.Id = products.Count + 1; // Increment ID
        products.Add(product);
        return RedirectToAction("List");
    }

    public IActionResult List()
    {
        return View(products); // Pass the product list to the view
    }

    public IActionResult Edit(int id)
    {
        var product = products.Find(p => p.Id == id);
        if (product == null) return NotFound();
        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product updatedProduct)
    {
        var product = products.Find(p => p.Id == updatedProduct.Id);
        if (product != null)
        {
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.StockQuantity = updatedProduct.StockQuantity;
            product.Category = updatedProduct.Category;
            product.ImageUrl = updatedProduct.ImageUrl;
        }

        return RedirectToAction("List");
    }

    public IActionResult Delete(int id)
    {
        var product = products.Find(p => p.Id == id);
        if (product != null) products.Remove(product);
        return RedirectToAction("List");
    }
}