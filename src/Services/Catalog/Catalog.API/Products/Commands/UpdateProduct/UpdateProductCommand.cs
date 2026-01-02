using Catalog.API.DTOs;
using MediatR;

namespace Catalog.API.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand
     (
        Guid Id,
        string Name,
        string Category,
        string Description,
        string ImageFile,
        decimal Price) : IRequest<Result<string>>;
}
