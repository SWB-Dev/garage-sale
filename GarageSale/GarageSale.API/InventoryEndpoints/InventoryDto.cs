using GarageSale.API.ItemEndpoints;
using GarageSale.Shared.ItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageSale.API.InventoryEndpoints
{
	public class InventoryDto
	{
		public int Id { get; set; }
		public ItemDto Item { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
