
namespace MyApp.Application.UseCases.Products.CreateProduct
{
    public record CreateProductResponse(
        int Id,
        string Name,
        string? Description,
        DateTime CreationTime,
        bool IsActive);
}