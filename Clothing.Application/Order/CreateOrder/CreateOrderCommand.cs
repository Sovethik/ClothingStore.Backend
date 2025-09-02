using Clothing.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.Application.Order.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int UserId { get; set; }

        public List<ItemOrder> ItemsOrder { get; set; }
    }
}
