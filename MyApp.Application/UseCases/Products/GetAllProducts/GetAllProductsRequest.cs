using MediatR;

namespace MyApp.Application.UseCases.Products.GetAllProducts
{
    public record GetAllProductsRequest : IRequest<IEnumerable<GetAllProductsResponse>>;
}
