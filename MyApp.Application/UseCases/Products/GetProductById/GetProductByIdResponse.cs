namespace MyApp.Application.UseCases.Products.GetProductById
{
    public record GetProductByIdResponse(
        int Id,
        string Name,
        string? Description,
        DateTime CreationTime,
        bool IsActive);
}
