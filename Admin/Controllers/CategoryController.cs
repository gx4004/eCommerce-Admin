using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Admin.Controllers
{
    public class CategoryController : Controller
    {
        private static List<string> categories = new List<string> { "Electronics", "Books", "Clothing" };

        public IActionResult List()
        {
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string category)
        {
            if (!string.IsNullOrEmpty(category))
            {
                categories.Add(category); 
                return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            if (id < categories.Count)
            {
                var category = categories[id];
                return View(category);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Edit(int id, string category)
        {
            if (id < categories.Count && !string.IsNullOrEmpty(category))
            {
                categories[id] = category;  
                return RedirectToAction("List");
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            if (id < categories.Count)
            {
                categories.RemoveAt(id);  
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }
    }
}