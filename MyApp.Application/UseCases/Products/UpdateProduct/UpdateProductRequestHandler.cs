using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.Data;
using MyApp.Domian.Entities;

namespace MyApp.Application.UseCases.Products.UpdateProduct
{
    internal class UpdateProductRequestHandler : AsyncRequestHandler<UpdateProductRequest>
    {
        public readonly IMyAppContext _context;

        public UpdateProductRequestHandler(IMyAppContext context)
        {
            _context = context;
        }

        private bool IsValid(Product product)
        {
            UpdateProductValidation validation = new UpdateProductValidation();
            ValidationResult resultValidation = validation.Validate(product);
            return resultValidation.IsValid;
        }

        protected override async Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {

            var product = await _context.Products.SingleAsync(x => x.Id == request.Id, cancellationToken);

            Product updateProduct = new Product(
                request.Name,
                request.Description,
                DateTime.Now,
                true
            );

            if (IsValid(updateProduct))
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.IsActive = request.IsActive;

                await _context.SaveChangesAsync(cancellationToken);
            }

        }
    }
}
