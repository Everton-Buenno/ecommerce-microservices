using Catalog.API.DTOs;
using Catalog.API.Entities;
using MediatR;

namespace Catalog.API.Products.Queries.GetProductById
{
     public record GetProductByIdQuery(Guid Id) : IRequest<Result<Product>>;
}
