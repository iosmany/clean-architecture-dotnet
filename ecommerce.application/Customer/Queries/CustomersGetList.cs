
namespace ecommerce.application.Customer.Queries;

using ecommerce.application.Persistence;
using ecommerce.core;
using LanguageExt;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

sealed class CustomersGetList : ICustomersGetList
{
    readonly ICustomerRepository _repository;
    public CustomersGetList(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Either<IReadOnlyCollection<IError>, IEnumerable<CustomerModel>>> ExecuteAsync(CancellationToken cancellationToken)
    {
        return (await _repository.GetAllAsync(cancellationToken))
            .Select(m => new CustomerModel(m)).ToList();
    }
}
