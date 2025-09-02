using Clothing.Application.Exceptions;
using Clothing.Application.Interfaces;
using Clothing.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.Application.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IClothingDbContext _context;
        private readonly ILogger<CreateOrderCommandHandler> _logger;

        public CreateOrderCommandHandler(IClothingDbContext context, ILogger<CreateOrderCommandHandler> logger)
        { 
           _context = context;
            _logger = logger;
        }


        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var listProductId = request.ItemsOrder;

            await IsProducts(listProductId);


            OrderProducts order = new OrderProducts()
            {
                UserId = request.UserId,
                DateOrder = DateTime.UtcNow,
                ItemsOrder = request.ItemsOrder
            };

            await _context.Orders.AddAsync(order);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"Был создан заказ: {order.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _logger.LogError($"Не удалось сохранить {order.GetType()}. Причина: {ex.Message}");
            }

            return order.Id;
        }


        public async Task IsProducts(List<ItemOrder> listProductId)
        {

            foreach(var item in listProductId)
            {
                var result = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.ProductId);

                if (result == null)
                    throw new NotFoundException(nameof(Product),item.ProductId);
            }

        
        }

    }
}
