using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Admin.Controllers
{
    public class ProductController : Controller
    {
        private static List<string> products = new List<string> { "Laptop", "Book", "T-shirt" };

        public IActionResult List()
        {
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string product)
        {
            if (!string.IsNullOrEmpty(product))
            {
                products.Add(product);
                return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            if (id < products.Count)
            {
                var product = products[id];
                return View(product);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Edit(int id, string product)
        {
            if (id < products.Count && !string.IsNullOrEmpty(product))
            {
                products[id] = product;  
                return RedirectToAction("List");
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            if (id < products.Count)
            {
                products.RemoveAt(id); 
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }
    }
}