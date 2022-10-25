using FluentValidation;
using MyApp.Domian.Entities;

namespace MyApp.Application.UseCases.Products.DeleteProduct
{
    class DeleteProductValidation : AbstractValidator<Product>
    {
        public DeleteProductValidation()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotNull().WithMessage("It must be a valid Id");
        }
    }
}
