using Clothing.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.Application.Interfaces
{
    public interface IClothingDbContext
    {
        DbSet<OrderProducts> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ItemOrder> ItemsOrder { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
