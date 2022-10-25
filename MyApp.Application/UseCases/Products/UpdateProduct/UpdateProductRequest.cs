using MediatR;

namespace MyApp.Application.UseCases.Products.UpdateProduct
{
    public record UpdateProductRequest(int Id, string Name,
        string? Description,
        bool IsActive) : IRequest;

}
