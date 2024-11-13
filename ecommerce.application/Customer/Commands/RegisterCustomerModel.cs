using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.Customer.Commands
{
    public class RegisterCustomerModel
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DoB { get; set; }
    }
}
