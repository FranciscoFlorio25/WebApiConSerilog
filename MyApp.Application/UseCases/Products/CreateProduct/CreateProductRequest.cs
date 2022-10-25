using MediatR;

namespace MyApp.Application.UseCases.Products.CreateProduct
{
    public record CreateProductRequest(
        string Name,
        string? Description) : IRequest<CreateProductResponse>;
}
