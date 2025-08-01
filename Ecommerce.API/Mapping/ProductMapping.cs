﻿using AutoMapper;
using Ecommerce.Core.DTO.Photos;
using Ecommerce.Core.DTO.Products;
using Ecommerce.Core.Entities.Product;

namespace Ecommerce.API.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(x => x.CategoryName, op => op.MapFrom(src => src.Category.Name))

                 .ReverseMap();

            CreateMap<Photo, PhotoDTO>().ReverseMap();

            CreateMap<AddProductDTO, Product>().ForMember(x => x.Photos, op => op.Ignore()).ReverseMap();//don't map Photos property because it will be handled separately in the service layer
            CreateMap<UpdateProductDTO, Product>().ForMember(x => x.Photos, op => op.Ignore()).ReverseMap();

        }
    }
}
