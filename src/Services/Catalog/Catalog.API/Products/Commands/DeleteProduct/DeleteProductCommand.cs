using Catalog.API.DTOs;
using MediatR;

namespace Catalog.API.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand
    (
        Guid Id
    ):IRequest<Result<string>>;
}
