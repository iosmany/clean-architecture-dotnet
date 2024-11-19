using ecommerce.domain.Entities.Sales;
using ecommerce.persistence.Shared;


namespace ecommerce.persistence.Sales;

using application.Persistence;
using ecommerce.application;

internal class SaleRepository : Repository<Sale>, ISaleRepository
{
    public SaleRepository(IDatabaseService databaseService) : base(databaseService)
    {
    }

}

