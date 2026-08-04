using AutoMapper;
using Microservices.BackEnd.CouponAPI.Models;
using Microservices.BackEnd.CouponAPI.Models.Dto;

namespace Microservices.BackEnd.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
