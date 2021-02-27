using GarageSale.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageSale.API.ItemEndpoints
{
	public static class ItemMapper
	{
		public static ItemDto MapDto(this Item item)
		{
			var dto = new ItemDto
			{
				Id = item.Id,
				Description = item.Description,
				ImageUrl = item.ImageUrl,
				IsForSale = item.IsForSale,
				Name = item.Name
			};

			return dto;
		}

		public static Item MapItem(this ItemDto dto)
		{
			var item = new Item
			{
				Id = dto.Id,
				Description = dto.Description,
				ImageUrl = dto.ImageUrl,
				IsForSale = dto.IsForSale,
				Name = dto.Name
			};

			return item;
		}

		public static void UpdateItem(this Item item,ItemDto dto)
		{
			foreach (var prop in item.GetType().GetProperties().Where(p => p.Name != "Id"))
			{
				var itemProp = item.GetType().GetProperty(prop.Name);
				var dtoProp = dto.GetType().GetProperty(prop.Name);

				var newValue = dtoProp.GetValue(dto);

				itemProp.SetValue(item, newValue);
			}
		}
	}
}
