using Catalog.API.Data;
using Catalog.API.DTOs;
using Catalog.API.Entities;
using MediatR;
using MongoDB.Driver;

namespace Catalog.API.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<Product>>
    {

        private readonly ICatalogContext _catalogContext;

        public GetProductByIdQueryHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<Result<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _catalogContext.Products.Find( o => o.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if(product is null)
                return Result<Product>.Failure($"Produto com Id {request.Id} não foi encontrado.");

            return Result<Product>.Success(product);
        }
    }
}
