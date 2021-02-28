using GarageSale.Shared.ItemDtos;
using GarageSale.Shared.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageSale.Site.Pages.Item
{
	public partial class ViewItem
	{
		[Parameter]
		public int Id { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Dto = await Service.GetByIdAsync(Id);
		}
	}
}
