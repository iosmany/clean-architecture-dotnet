

using ecommerce.application.Sale.Repository;

namespace ecommerce.application.Sale.Queries;

class GetCustomerSalesQuery : IGetCustomerSalesQuery
{
    readonly ISalesRepositoryFacade _repositoryFacade;
    public GetCustomerSalesQuery(ISalesRepositoryFacade repositoryFacade)
    {
        _repositoryFacade = repositoryFacade;
    }

    public Task ExecuteAsync(CustomerSalesRequest request, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
