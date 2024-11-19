using ecommerce.application.Persistence;
using ecommerce.core;

namespace ecommerce.application.Product.Queries;
internal class ProductGetList : IProductGetList
{
    readonly IProductRepository _repository;
    public ProductGetList(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Either<IReadOnlyCollection<IError>, IEnumerable<ProductModel>>> ExecuteAsync(CancellationToken cancellationToken)
        => (await _repository.GetAllAsync())
            .Select(m => new ProductModel(m)).ToList();
}
