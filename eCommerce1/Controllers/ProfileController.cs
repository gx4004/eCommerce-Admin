using Microsoft.AspNetCore.Mvc;

namespace eCommerce1.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult MyOrders()
        {
            return View();
        }

        public IActionResult MyProducts()
        {
            return View();
        }
    }
}