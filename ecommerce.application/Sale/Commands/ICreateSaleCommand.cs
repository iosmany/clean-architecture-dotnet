using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.Sale.Commands
{
    public interface ICreateSaleCommand
    {
        Task ExecuteAsync(CreateSaleModel model, CancellationToken cancellationToken);
    }
}
