using AutoMapper;
using Microservices.BackEnd.ProductAPI.Models;
using Microservices.BackEnd.ProductAPI.Models.Dto;

namespace Microservices.BackEnd.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
