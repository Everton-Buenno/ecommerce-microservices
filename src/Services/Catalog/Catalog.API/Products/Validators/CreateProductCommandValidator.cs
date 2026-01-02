using Catalog.API.Products.Commands.CreateProduct;
using FluentValidation;

namespace Catalog.API.Products.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .Length(2, 150).WithMessage(" Nome deve ter entre 2 e 150 caracteres");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Categoria é obrigatória");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Preço deve ser maior que zero");
        }
    }
}
