using AutoMapper;
using Clothing.Application.Mappings;
using Clothing.Domain.Entity;

namespace Clothing.Presentation.Models
{
    public class ItemsOrderDto : IMapWith<ItemOrder>
    {
        public int ProductId { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<ItemsOrderDto, ItemOrder>();
    }
}
