namespace MyApp.Application.UseCases.Products.GetAllProducts
{
    public record GetAllProductsResponse(
        int Id,
        string Name,
        string? Description,
        DateTime CreationDate,
        bool IsActive
        );

}
