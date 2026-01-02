using Catalog.API.Data;
using Catalog.API.DTOs;
using MediatR;
using MongoDB.Driver;

namespace Catalog.API.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<string>>
    {

        private readonly ICatalogContext _catalogContext;

        public DeleteProductCommandHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }
        public async Task<Result<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _catalogContext.Products.Find(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (product == null)
            {
                return Result<string>.Failure($"Produto com Id {request.Id} não encontrado.");
            }
            await _catalogContext.Products.DeleteOneAsync(p => p.Id == request.Id, cancellationToken);
            return Result<string>.Success($"Produto com Id {request.Id} deletado com sucesso.");
        }
    }
}
