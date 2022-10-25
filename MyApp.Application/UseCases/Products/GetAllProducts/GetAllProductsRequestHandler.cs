using MediatR;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.Data;

namespace MyApp.Application.UseCases.Products.GetAllProducts
{
    internal class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, IEnumerable<GetAllProductsResponse>>
    {
        public readonly IMyAppContext _context;

        public GetAllProductsRequestHandler(IMyAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.AsNoTracking().ToListAsync(cancellationToken);

            return products.Select(x => new GetAllProductsResponse(x.Id, x.Name, x.Description, x.CreationDate, x.IsActive));
        }
    }
}
