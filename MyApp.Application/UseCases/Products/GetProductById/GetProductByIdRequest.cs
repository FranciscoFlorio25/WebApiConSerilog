using MediatR;

namespace MyApp.Application.UseCases.Products.GetProductById
{
    public record GetProductByIdRequest(int Id) : IRequest<GetProductByIdResponse>;

}
