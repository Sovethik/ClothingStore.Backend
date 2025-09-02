using Clothing.Application.Interfaces;
using Clothing.Domain.Entity;
using Clothing.Infrastrucure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.Infrastrucure
{
    internal class ClothingDbContext : DbContext, IClothingDbContext
    {
        public DbSet<OrderProducts> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ItemOrder> ItemsOrder { get; set; }

        public ClothingDbContext(DbContextOptions<ClothingDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ItemOrderConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
