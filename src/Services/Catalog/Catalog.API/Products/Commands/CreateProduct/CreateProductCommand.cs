using Catalog.API.DTOs;
using MediatR;

namespace Catalog.API.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        string Category,
        string Description,
        string ImageFile,
        decimal Price) : IRequest<Result<Guid>>;
}
