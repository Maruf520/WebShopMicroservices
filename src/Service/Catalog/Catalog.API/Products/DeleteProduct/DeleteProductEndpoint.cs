
using Catalog.API.Products.UpdateProduct;

namespace Catalog.API.Products.DeleteProduct
{

    public record DeleteProcutResponse(bool IsSuccess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(Id));
                var response = result.Adapt<DeleteProcutResponse>();
                return Results.Ok(response);
            })
                .WithName("DeleteProducts")
                .Produces<UpdateProductCommand>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Delete Product")
                .WithDescription("Delete Product");

        }
    }
}
