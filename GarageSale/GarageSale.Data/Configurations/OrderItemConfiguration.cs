using GarageSale.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSale.Data.Configurations
{
	public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.OwnsOne(i => i.ItemDetails, d =>
			{
				d.WithOwner();

				d.Property(oid => oid.ItemName)
					.HasMaxLength(50)
					.IsRequired();
			});
		}
	}
}
