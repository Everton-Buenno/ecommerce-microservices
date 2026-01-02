using Catalog.API.DTOs;
using Catalog.API.Entities;
using MediatR;

namespace Catalog.API.Products.Queries.GetProductsByCategory
{
    public record GetProductsByCategoryQuery
    (
        string Category):IRequest<Result<List<Product>>>;
}
