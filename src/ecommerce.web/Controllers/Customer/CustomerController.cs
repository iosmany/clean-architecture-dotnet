using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.web.Controllers.Customer
{

    [Authorize]
    public class CustomerController : Controller
    {
       

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
