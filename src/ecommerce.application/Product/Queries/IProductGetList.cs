using ecommerce.core;
using ecommerce.core.Commands;

namespace ecommerce.application.Product.Queries;

public interface IProductGetList : IQuery<Either<IReadOnlyCollection<IError>, IEnumerable<ProductModel>>>
{

}
