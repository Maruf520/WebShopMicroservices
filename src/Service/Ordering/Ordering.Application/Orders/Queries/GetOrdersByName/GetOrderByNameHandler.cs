
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Extentions;

namespace Ordering.Application.Orders.Queries.GetOrdersByName
{
    internal class GetOrderByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
    {
        public async Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
        {
            var orders = await dbContext.Orders.Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(x => x.OrderName.Value.Contains(query.name))
                .OrderBy(x => x.OrderName)
                .ToListAsync(cancellationToken);

            return new GetOrdersByNameResult(orders.ToOrderDtoList());
        }
    }
}
