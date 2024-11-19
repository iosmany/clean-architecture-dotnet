namespace ecommerce.application.Sale.Persistence;

using domain.Entities.Sales;
interface ISaleRepositoryFacade
{
    Task<IEnumerable<Sale>> SalesByCustomerAsync(CancellationToken? cancellationToken= null);
}
