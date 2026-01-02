using Catalog.API.DTOs;
using Catalog.API.Entities;
using MediatR;

namespace Catalog.API.Products.Queries.GetProducts
{
    public record GetProductsQuery
    ():IRequest<Result<List<Product>>>;
    
}
