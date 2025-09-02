using AutoMapper;
using Clothing.Application.Mappings;
using Clothing.Application.Order.CreateOrder;
using Clothing.Domain.Entity;

namespace Clothing.Presentation.Models
{
    public class CreateOrderDto : IMapWith<CreateOrderCommand>
    {
        public List<ItemsOrderDto> ItemOrders { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
                .ForMember(dest => dest.ItemsOrder, opt => opt.MapFrom(scr => scr.ItemOrders));
    
        }
    }
}
