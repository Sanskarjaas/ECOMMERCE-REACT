using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class SeedContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.Json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
            }
            if (!context.ProductBrands.Any())
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.Json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }
            if (!context.ProductBrands.Any())
            {
                var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.Json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                context.Products.AddRange(products);
            }
            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}