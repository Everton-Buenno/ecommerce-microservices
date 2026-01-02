using Catalog.API.Data;
using Catalog.API.DTOs;
using Catalog.API.Entities;
using MediatR;
using MongoDB.Driver;

namespace Catalog.API.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<List<Product>>>
    {

        private readonly ICatalogContext _catalogContext;

        public GetProductsQueryHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }
        public async Task<Result<List<Product>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _catalogContext.Products.Find(_ => true).ToListAsync(cancellationToken) is List<Product> products && products.Any()
                ? Result<List<Product>>.Success(products)
                : Result<List<Product>>.Failure("No products found");
        }
    }
}
