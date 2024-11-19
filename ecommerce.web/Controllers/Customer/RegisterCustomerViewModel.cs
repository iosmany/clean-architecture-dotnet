using ecommerce.application.Customer.Commands;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.web.Controllers.Customer
{
    public class RegisterCustomerViewModel
    {
        [MaxLength(80)]
        [Required(AllowEmptyStrings =false)]
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? DoB { get; set; }

     
    }
}
