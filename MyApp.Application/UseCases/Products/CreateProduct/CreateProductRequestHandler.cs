using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using MyApp.Application.Data;
using MyApp.Domian.Entities;

namespace MyApp.Application.UseCases.Products.CreateProduct
{
    internal class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        public readonly IMyAppContext _context;
        public readonly ILogger<CreateProductRequestHandler> _logger;

        public CreateProductRequestHandler(IMyAppContext context, ILogger<CreateProductRequestHandler> logger)
        {
            _logger = logger;
            _context = context;
        }
        private static bool IsValid(Product product)
        {
            CreateProductValidation validation = new CreateProductValidation();

            ValidationResult resultValidation = validation.Validate(product);

            return resultValidation.IsValid;

        }
        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Product product = new(request.Name, request.Description, DateTime.Now, isActive: true);

            _logger.LogInformation("Executing the product handle");

            if (IsValid(product))
            {
                _context.Products.Add(product);

                await _context.SaveChangesAsync(cancellationToken);

                _logger.LogInformation("Product added {0}", product.Id.ToString());
            }
            if (!IsValid(product))
            {
                _logger.LogInformation("Product coudn't be added {0}, insert a valid product", product.Id.ToString());
            }
            return new CreateProductResponse(product.Id, product.Name, product.Description, product.CreationDate, product.IsActive);
        }
    }
}
