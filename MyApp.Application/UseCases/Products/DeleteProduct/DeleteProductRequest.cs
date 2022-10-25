using MediatR;

namespace MyApp.Application.UseCases.Products.DeleteProduct
{
    public record DeleteProductRequest(int id) : IRequest;
}
