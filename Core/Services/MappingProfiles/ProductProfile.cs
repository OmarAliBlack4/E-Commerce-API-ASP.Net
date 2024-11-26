using AutoMapper;
using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResultDTO>()
                .ForMember(d => d.BrandName, option => option.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.TypeName, option => option.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, option => option.MapFrom<PictureUrlResolver>());

            CreateMap<ProductBrand , BrandResultDTO>();
            CreateMap<ProductType , TypeResultDTO>();
        }
    }
}
