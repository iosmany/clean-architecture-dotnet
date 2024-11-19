using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.Customer.Commands
{
    internal interface IEditCustomerCommand
    {
        Task ExcecuteAsync(EditCustomerModel model, CancellationToken cancellationToken);
    }
}
