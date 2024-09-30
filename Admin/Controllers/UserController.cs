using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Admin.Controllers
{
    public class UserController : Controller
    {
        private static List<string> users = new List<string> { "admin@example.com", "user@example.com" };

        public IActionResult List()
        {
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                users.Add(email);  
                return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            if (id < users.Count)
            {
                var user = users[id];
                return View(user);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Edit(int id, string email)
        {
            if (id < users.Count && !string.IsNullOrEmpty(email))
            {
                users[id] = email;  
                return RedirectToAction("List");
            }
            return View(email);
        }

        public IActionResult Delete(int id)
        {
            if (id < users.Count)
            {
                users.RemoveAt(id); 
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }
    }
}