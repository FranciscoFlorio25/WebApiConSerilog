using MediatR;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.Data;

namespace MyApp.Application.UseCases.Products.GetProductById
{
    internal class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        public readonly IMyAppContext _context;

        public GetProductByIdRequestHandler(IMyAppContext context)
        {
            _context = context;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleAsync(x => x.Id == request.Id, cancellationToken);

            return new GetProductByIdResponse(product.Id, product.Name, product.Description, product.CreationDate, product.IsActive);
        }
    }
}
