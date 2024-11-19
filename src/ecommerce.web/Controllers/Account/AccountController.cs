using Microsoft.AspNetCore.Mvc;

namespace ecommerce.web.Controllers.Account
{
    [Route("[controller]")]
    public class AccountController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
