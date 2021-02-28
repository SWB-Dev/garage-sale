using GarageSale.Shared.ItemDtos;
using GarageSale.Shared.Services;
using GarageSale.Site.Common;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageSale.Site.Pages.Item
{
	public partial class ViewItems
	{
		public IEnumerable<ItemDto> items;


		protected override async Task OnInitializedAsync()
		{
			items = await Service.GetAllAsync();
		}
	}
}
