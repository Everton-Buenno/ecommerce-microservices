using Catalog.API.Data;
using Catalog.API.DTOs;
using Catalog.API.Entities;
using MediatR;

namespace Catalog.API.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Guid>>
    {

        private readonly ICatalogContext _context;

        public CreateProductCommandHandler(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Category = request.Category,
                Description = request.Description,
                ImageFile = request.ImageFile,
                Price = request.Price
            };
            await _context.Products.InsertOneAsync(product, cancellationToken: cancellationToken);
            return Result<Guid>.Success(product.Id);
        }
    }
}
