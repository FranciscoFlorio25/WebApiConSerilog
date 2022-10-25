using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.UseCases.Products.CreateProduct;
using MyApp.Application.UseCases.Products.DeleteProduct;
using MyApp.Application.UseCases.Products.GetAllProducts;
using MyApp.Application.UseCases.Products.GetProductById;
using MyApp.Application.UseCases.Products.UpdateProduct;

namespace MyApp.Api.Routes
{
    public static class ProductsRoutes
    {
        public static IEndpointRouteBuilder MapProducts(this IEndpointRouteBuilder builder)
        {
            builder.MapGet(pattern: "/Products", async ([FromServices] IMediator mediator)
                => Results.Ok(await mediator.Send(request: new GetAllProductsRequest())))
                .WithName(endpointName: "GetProducts")
                .Produces<IEnumerable<GetAllProductsResponse>>(StatusCodes.Status200OK, contentType: "application/json");

            builder.MapPost(pattern: "/Products", async ([FromServices] IMediator mediator, [FromBody] CreateProductRequest request)
                => Results.Ok(await mediator.Send(request)))
                .WithName(endpointName: "CreateProducts")
                .Produces<CreateProductRequest>(StatusCodes.Status200OK, contentType: "application/json");

            builder.MapDelete(pattern: "/Products/{id}", async ([FromServices] IMediator mediator, [FromRoute] int id)
                => Results.Ok(await mediator.Send(request: new DeleteProductRequest(id))))
                .WithName(endpointName: "DeleteProducts");

            builder.MapPut(pattern: "/Products/Update", async ([FromServices] IMediator mediator, [FromBody] UpdateProductRequest request)
                => Results.Ok(await mediator.Send(request)))
                .WithName(endpointName: "UpdateProduct")
                .Produces<UpdateProductRequest>(StatusCodes.Status200OK, contentType: "application/json");

            builder.MapGet(pattern: "/Products/{id}", async ([FromServices] IMediator mediator, [FromRoute] int id)
                => Results.Ok(await mediator.Send(request: new GetProductByIdRequest(id))))
                .WithName(endpointName: "GetProductById")
                .Produces<GetProductByIdResponse>(StatusCodes.Status200OK, contentType: "application/json");
            return builder;
        }
    }
}
