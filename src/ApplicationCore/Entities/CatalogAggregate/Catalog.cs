using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.CatalogAggregate
{
    public class Catalog : BaseEntity, IAggregateRoot
    {
        public Catalog()
        {
            // required by EF
        }

        public Catalog(int catalogBrandId,
            int catalogTypeId,
            string description,
            string name,
            string pictureUri,
            decimal price,
            CatalogBrand catalogBrand,
            CatalogType catalogType)
        {
            Guard.Against.Null(catalogBrandId, nameof(catalogBrandId));
            Guard.Against.Null(catalogTypeId, nameof(catalogTypeId));
            Guard.Against.Null(price, nameof(price));

            Guard.Against.NullOrEmpty(name, nameof(name));

            CatalogBrand = catalogBrand;
            CatalogType = catalogType;
        }

        public int CatalogBrandId { get; set; }
        public int CatalogTypeId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string PictureUri { get; set; }
        public decimal Price { get; set; }
        public CatalogBrand CatalogBrand { get; set; }
        public CatalogType CatalogType { get; set; }
    }
}
