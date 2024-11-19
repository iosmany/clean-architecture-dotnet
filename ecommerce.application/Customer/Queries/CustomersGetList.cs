
namespace ecommerce.application.Customer.Queries;

using domain.Entities.Customers;
using ecommerce.application.Persistence;

sealed class CustomersGetList : ICustomersGetList
{
    readonly ICustomerRepositoryFacade _repositoryFacade;
    public CustomersGetList(ICustomerRepositoryFacade repositoryFacade)
    {
        _repositoryFacade = repositoryFacade;
    }

    public async IAsyncEnumerable<CustomerModel> GetAsync(Func<Customer, bool> predicate)
    {
        await foreach (var customer in _repositoryFacade.GetCustomersAsync(predicate))
        {
            yield return new CustomerModel();
        }
    }
}
