using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer : IDbInitializer
    {
        private readonly StoreContext _storeContext;

        public DbInitializer(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task InitializeAsync()
        {

            try
            {
                if (_storeContext.Database.GetPendingMigrations().Any())
                    await _storeContext.Database.MigrateAsync();

                if (!_storeContext.ProductTypes.Any())
                {
                    var typeData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                    if (types is not null && types.Any())
                    {
                        await _storeContext.ProductTypes.AddRangeAsync(types);
                        await _storeContext.SaveChangesAsync();
                    }
                }
                if (!_storeContext.ProductBrands.Any())
                {
                    var brandData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                    if (brands is not null && brands.Any())
                    {
                        await _storeContext.ProductBrands.AddRangeAsync(brands);
                        await _storeContext.SaveChangesAsync();
                    }
                }
                if (!_storeContext.Products.Any())
                {
                    var producstData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(producstData);
                    if (products is not null && products.Any())
                    {
                        await _storeContext.Products.AddRangeAsync(products);
                        await _storeContext.SaveChangesAsync();
                    }
                }
            }
            catch(Exception) 
            {
                throw;
            }
        }
    }
}
