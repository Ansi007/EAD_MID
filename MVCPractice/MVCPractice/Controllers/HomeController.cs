using Microsoft.AspNetCore.Mvc;
using MVCPractice.Models;

namespace MVCPractice.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public ViewResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ViewResult SignUp(Customer c)
        {
            if (ModelState.IsValid)
            {
                if (CustomerRepositry.AddCustomer(c) > 0)
                    return View("SignIn");
            }
            return View();
        }

        [HttpPost]
        public ViewResult SignIn(Customer c)
        {
       //     if (ModelState.IsValid)
         //   {
                if (CustomerRepositry.ValidateCustomer(c))
                    return View("Index");
           // }
            return View();
        }

    }
}
