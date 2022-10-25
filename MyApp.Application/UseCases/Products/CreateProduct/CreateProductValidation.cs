using FluentValidation;
using MyApp.Domian.Entities;

namespace MyApp.Application.UseCases.Products.CreateProduct
{
    class CreateProductValidation : AbstractValidator<Product>
    {
        public CreateProductValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product name must not be null");
            RuleFor(x => x.Name).MaximumLength(70).WithMessage("Product name must not exceed a length of 70 characters");
            RuleFor(x => x.Description).MaximumLength(120).WithMessage("Product description must not exceed a length of 120 characters");
        }
    }
}
