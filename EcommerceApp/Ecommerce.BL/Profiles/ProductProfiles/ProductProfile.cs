using AutoMapper;
using Ecommerce.BL.DTOs.OrderDto;
using Ecommerce.BL.DTOs.OrderItemDto;
using Ecommerce.BL.DTOs.ProductDto;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Profiles.ProductProfiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateDto, Product>().ReverseMap();     
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
                     
        }
    }
}
