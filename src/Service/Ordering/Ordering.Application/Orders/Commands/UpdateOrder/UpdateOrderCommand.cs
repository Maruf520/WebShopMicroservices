
namespace Ordering.Application.Orders.Commands.UpdateOrder;

 public record UpdateOrderCommand(OrderDto Order): ICommand<UpdateOrderResult>;

public record UpdateOrderResult(bool IsSucces);

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Order.Id).NotEmpty().WithMessage("Id is Required");
        RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Order Name is Required");
        RuleFor(x => x.Order.CustomerId).NotEmpty().WithMessage("CUstomerId is Required");
    }
}

