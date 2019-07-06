using Microsoft.eShopWeb.ApplicationCore.Entities.CatalogAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogRepository : EfRepository<Catalog>, ICatalogRepository
    {
        public CatalogRepository(CatalogContext dbContext) : base(dbContext)
        {
        }
    }
}
