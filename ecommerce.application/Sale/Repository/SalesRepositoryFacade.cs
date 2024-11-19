using ecommerce.application.Persistence;

namespace ecommerce.application.Sale.Repository;

sealed class SalesRepositoryFacade : ISalesRepositoryFacade
{
    readonly ISaleRepository _repository;
    public SalesRepositoryFacade(ISaleRepository repository)
    {
        _repository = repository;
    }


}
