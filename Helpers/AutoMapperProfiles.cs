using AutoMapper;
using NwOrdersAPI.DTOs;
using NwOrdersAPI.Entities;

namespace NwOrdersAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {            
            CreateMap<SelectOrderReturnModel, OrderDto>();
            CreateMap<SelectOrderItemsReturnModel, OrderItemsDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Product, ProductDto>();
        }

    }
}
