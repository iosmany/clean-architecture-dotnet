

namespace ecommerce.application.Persistence;

using ecommerce.domain.Entities.Products;
internal interface IProductRepositoryFacade 
{
    IRepository<Product> GetRepository();
}
