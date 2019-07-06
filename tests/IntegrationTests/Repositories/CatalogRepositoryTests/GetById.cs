using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Entities.CatalogAggregate;
using Microsoft.eShopWeb.Infrastructure.Data;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.eShopWeb.IntegrationTests.Repositories.CatalogRepositoryTests
{
    public class GetById
    {
        private readonly CatalogContext _catalogContext;
        private readonly CatalogRepository _catalogRepository;
        private readonly ITestOutputHelper _output;

        public GetById(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<CatalogContext>()
                .UseInMemoryDatabase(databaseName: "TestCatalog")
                .Options;
            _catalogContext = new CatalogContext(dbOptions);
            _catalogRepository = new CatalogRepository(_catalogContext);
        }

        [Fact]
        public async Task GetCatalog()
        {
            var catalogBrand = new CatalogBrand { Brand = "brand", Id = 1 };
            var catalogType = new CatalogType { Type = "type", Id = 1 };
            var existingCatalog = new Catalog(1, 1, "desc", "name", "picUri", 10m, catalogBrand, catalogType);
            _catalogContext.Catalog.Add(existingCatalog);
            _catalogContext.SaveChanges();

            var catalog = await _catalogRepository.GetByIdAsync(1);
            Assert.NotNull(catalog.CatalogBrand);
            Assert.NotNull(catalog.CatalogType);
        }
    }
}
