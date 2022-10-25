using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.Data;
using MyApp.Domian.Entities;

namespace MyApp.Application.UseCases.Products.DeleteProduct
{
    internal class DeleteProductRequestHandler : AsyncRequestHandler<DeleteProductRequest>
    {
        public readonly IMyAppContext _context;

        public DeleteProductRequestHandler(IMyAppContext context)
        {
            _context = context;
        }
        private bool IsValid(Product product)
        {
            DeleteProductValidation validation = new DeleteProductValidation();
            ValidationResult resultValidation = validation.Validate(product);
            return resultValidation.IsValid;
        }

        protected override async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleAsync(x => x.Id == request.id, cancellationToken);

            if (IsValid(product) && product != null)
            {
                _context.Products.Remove(product);

                await _context.SaveChangesAsync(cancellationToken);
            }

        }
    }
}
