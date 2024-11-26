using Domain.Contracts;
using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.ProductSpesificationParameters;

namespace Services.Specifications
{
    internal class ProductCountSpesifications : Specifications<Product>
    {
        public ProductCountSpesifications(ProductSpesificationParameters parameters)
            : base(product =>
            (!parameters.brandId.HasValue || product.BrandId == parameters.brandId.Value) &&
            (!parameters.typeId.HasValue || product.TypeId == parameters.typeId.Value) &&
            (string.IsNullOrWhiteSpace(parameters.Search) || product.Name.ToLower().Contains(parameters.Search.ToLower().Trim())))
        {     
        }
    }
}
