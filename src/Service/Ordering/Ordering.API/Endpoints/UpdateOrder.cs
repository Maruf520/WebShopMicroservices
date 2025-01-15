
using Ordering.Application.Orders.Commands.UpdateOrder;

namespace Ordering.API.Endpoints;

public record UpdateOrderRequest(OrderDto Order);
public record UpdateOrderRespnse(bool IsSuccess);
public class UpdateOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders", async (UpdateOrderRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateOrderCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateOrderRespnse>();

            return Results.Ok(response);
        })
        .WithName("UpdateOrder")
        .Produces<UpdateOrderRespnse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithDescription("Update Order");
    }
}

