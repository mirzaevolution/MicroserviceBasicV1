using AutoMapper;
using FxStore.ProductAPI.DtoModels;
using FxStore.ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FxStore.ProductAPI
{
    public class MapperConfiguration:Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
