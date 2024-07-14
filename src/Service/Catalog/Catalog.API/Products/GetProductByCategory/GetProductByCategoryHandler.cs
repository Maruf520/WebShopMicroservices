using Catalog.API.Products.GetProductById;

namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    public class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductByCategoryQuery> logger)
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            var result = await session.Query<Product>().Where(x => x.Category.Contains(query.Category)).ToListAsync();
            logger.LogInformation("GetProductByCategoryQueryHandler.Handle called with {query}", query);

            return new GetProductByCategoryResult(result);
        }
    }
}
