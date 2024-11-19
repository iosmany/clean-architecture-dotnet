using ecommerce.application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.Sale.Commands
{
    sealed class CreateSaleCommand: ICreateSaleCommand
    {
        public CreateSaleCommand()
        {
        }

        public Task ExecuteAsync(CreateSaleModel model, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
