using ecommerce.application.Sale.Persistence;
using ecommerce.core;

namespace ecommerce.application.Sale.Queries;
class GetCustomerSalesQuery : IGetCustomerSalesQuery
{
    readonly ISaleRepositoryFacade _repositoryFacade;
    public GetCustomerSalesQuery(ISaleRepositoryFacade repositoryFacade)
    {
        _repositoryFacade = repositoryFacade;
    }

    public async Task<Either<IReadOnlyCollection<IError>, IEnumerable<CustomerSaleModel>>> ExecuteAsync(CustomerSalesRequest request, CancellationToken cancellationToken)
        => (await _repositoryFacade.SalesByCustomerAsync(cancellationToken))
                .Select(s => new CustomerSaleModel(s)).ToList();
               


}
