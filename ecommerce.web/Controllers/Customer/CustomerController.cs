using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.web.Controllers.Customer
{
    using ecommerce.application.Customer.Commands;

    [Authorize]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        readonly IRegisterCustomerCommand _registerCustomerCommand;
        readonly ICreateCustomerViewModelFactory _viewModelFactory;

        public CustomerController(ICreateCustomerViewModelFactory viewModelFactory,
            IRegisterCustomerCommand registerCustomerCommand)
        {
            _viewModelFactory = viewModelFactory;   
            _registerCustomerCommand = registerCustomerCommand;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(_viewModelFactory.Create());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterCustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _registerCustomerCommand.ExecuteAsync(model.Build());

            return RedirectToAction("Index");
        }
    }
}
