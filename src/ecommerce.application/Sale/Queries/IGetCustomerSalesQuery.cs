using ecommerce.core.Commands;
using ecommerce.core;

namespace ecommerce.application.Sale.Queries;

using Response = Either<IReadOnlyCollection<IError>, IEnumerable<CustomerSaleModel>>;
public interface IGetCustomerSalesQuery : IQuery<CustomerSalesRequest, Response>
{

}
