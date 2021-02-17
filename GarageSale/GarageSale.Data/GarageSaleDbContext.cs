using GarageSale.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSale.Data
{
	public class GarageSaleDbContext : DbContext
	{
		public DbSet<Item> Items { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Inventory> Inventory { get; set; }
		public GarageSaleDbContext(DbContextOptions options) : base(options) 
		{
			
		}
	}
}
