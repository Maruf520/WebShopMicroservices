
namespace Basket.API.Basket.CheckoutBasket;
public record CheckOutBasketRequest(BasketCheckoutDto BasketCheckoutDto);
public record ChechoutBasketResponse(bool IsSuccess);
public class CheckoutBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/checkout", async (CheckOutBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<CheckoutBasketCommand>();
                var result = await sender.Send(command);

                var response = result.Adapt<ChechoutBasketResponse>();

                return Results.Ok(response);
            })
            .WithName("CheckoutBasket")
            .Produces<ChechoutBasketResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Cehckout Basket")
            .WithDescription("Checkout Basket");
    }
}

