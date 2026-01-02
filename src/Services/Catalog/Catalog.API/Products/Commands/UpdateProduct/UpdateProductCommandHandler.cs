using Catalog.API.Data;
using Catalog.API.DTOs;
using MediatR;
using MongoDB.Driver;

namespace Catalog.API.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<string>>
    {

        private readonly ICatalogContext _catalogContext;

        public UpdateProductCommandHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<Result<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _catalogContext.Products.Find(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (product is null)
                return Result<string>.Failure($"Produto com Id {request.Id} não encontrado.");


            product.Name = request.Name;
            product.Category = request.Category;
            product.Description = request.Description;
            product.Price = request.Price;
            product.ImageFile = request.ImageFile;
            await _catalogContext.Products.ReplaceOneAsync(p => p.Id == product.Id, product, cancellationToken: cancellationToken);
            return Result<string>.Success("Produto atualizado com sucesso.");
        }
    }
}
