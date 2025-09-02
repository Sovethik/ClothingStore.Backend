using Clothing.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.Infrastrucure.EntityTypeConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderProducts>
    {
        public void Configure(EntityTypeBuilder<OrderProducts> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            builder.HasMany(item => item.ItemsOrder)
                .WithOne(item => item.Order)
                .HasForeignKey(item => item.OrderId);

            builder.Property(o => o.DateOrder).IsRequired();

        }
    }
}
