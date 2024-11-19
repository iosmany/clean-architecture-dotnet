using ecommerce.application.Persistence;

namespace ecommerce.application.Sale.Persistence;

using domain.Entities.Sales;

class SaleRepositoryFacade 
{
    readonly ISaleRepository _saleRepository;
    public SaleRepositoryFacade(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;   
    }
    
    public IRepository<Sale> GetRepository() => _saleRepository;
}
