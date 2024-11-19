using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.Customer.Commands
{
    class EditCustomerCommand : IEditCustomerCommand
    {
        public EditCustomerCommand()
        {
        }

        public Task ExcecuteAsync(EditCustomerModel model, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
