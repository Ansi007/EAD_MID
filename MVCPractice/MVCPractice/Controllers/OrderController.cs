using Microsoft.AspNetCore.Mvc;
using MVCPractice.Models;

namespace MVCPractice.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public ViewResult PlaceOrder()
        {
            return View();
        }

        [HttpPost]
        public ViewResult PlaceOrder(Order o)
        {
            if(OrderRepositry.AddOrder(o) > 0) return View("Thanks",o);
            else return View();
        }
        public ViewResult Thanks()
        {
            return View();
        }
        public ViewResult AllOrders()
        {
            var orders = OrderRepositry.GetOrders();
            ViewBag.Orders = orders;
            return View();
        }
    }
}
