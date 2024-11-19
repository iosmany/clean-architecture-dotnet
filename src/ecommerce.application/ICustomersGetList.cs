using ecommerce.core.Commands;
using ecommerce.core;
using ecommerce.application.Customer;

namespace ecommerce.application;

using Response = Either<IReadOnlyCollection<IError>, IEnumerable<CustomerModel>>;

internal interface ICustomersGetList: IQuery<Response>
{

}
