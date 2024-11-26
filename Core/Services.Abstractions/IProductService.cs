using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IProductService
    {
        public Task<PaginatedResult<ProductResultDTO>> GetAllProductsAsync(ProductSpesificationParameters parameters);
        public Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync();
        public Task<IEnumerable<TypeResultDTO>> GetAlTypesAsync();
        public Task<ProductResultDTO?> GetProductByIdAsync(int id);
    }
}
