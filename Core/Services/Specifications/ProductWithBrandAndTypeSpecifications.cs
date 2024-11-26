using Domain.Contracts;
using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Shared.ProductSpesificationParameters;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypeSpecifications : Specifications<Product>
    {
        public ProductWithBrandAndTypeSpecifications(int id) 
            : base(product => product.Id == id )
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }
        
        public ProductWithBrandAndTypeSpecifications(ProductSpesificationParameters parameters)
            :base(product =>
            (!parameters.brandId.HasValue || product.BrandId == parameters.brandId.Value)&&
            (!parameters.typeId.HasValue || product.TypeId == parameters.typeId.Value) &&
            (string.IsNullOrWhiteSpace(parameters.Search)||product.Name.ToLower().Contains(parameters.Search.ToLower().Trim())))
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);

            ApplyPagination(parameters.pageIndex, parameters.pageSize);

            if (parameters.sort is not null )
            {
                switch(parameters.sort)
                {
                    case ProductSortingOptions.PriceDesc:
                        SetOrderByDescending(p => p.Price);
                        break;
                    case ProductSortingOptions.PriceAsc:
                        SetOrderBy(p => p.Price);
                        break;
                    case ProductSortingOptions.NameDesc:
                        SetOrderByDescending((p) => p.Name);
                        break;
                    default:
                        SetOrderBy(p => p.Name);
                        break;
                }
            }
        }
    }
}
