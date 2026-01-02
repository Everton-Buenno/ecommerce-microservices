using Catalog.API.Data;
using Catalog.API.DTOs;
using Catalog.API.Entities;
using MediatR;
using MongoDB.Driver;

namespace Catalog.API.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQueryCommand : IRequestHandler<GetProductsByCategoryQuery, Result<List<Product>>>
    {

        private readonly ICatalogContext _catalogContext;

        public GetProductsByCategoryQueryCommand(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<Result<List<Product>>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _catalogContext.Products.Find(o => o.Category == request.Category).ToListAsync(cancellationToken) is List<Product> products && products.Any()
                ? Result<List<Product>>.Success(products)
                : Result<List<Product>>.Failure($"No products found in category: {request.Category}");
        }
    }
}
