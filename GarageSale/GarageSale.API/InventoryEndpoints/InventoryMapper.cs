using GarageSale.API.ItemEndpoints;
using GarageSale.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageSale.API.InventoryEndpoints
{
	public static class InventoryMapper
	{
		public static InventoryDto MapDto(this Inventory inventory)
		{
			var item = inventory.Item;

			var dto = new InventoryDto
			{
				Id = inventory.Id,
				Item = item.MapDto(),
				Quantity = inventory.Quantity,
				UnitPrice = inventory.UnitPrice
			};

			return dto;
		}
	}
}
