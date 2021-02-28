using GarageSale.Shared.ItemDtos;
using GarageSale.Shared.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageSale.Site.Pages.Item
{
	public partial class EditItem
	{
		[Parameter]
		public int Id { get; set; }
		private ItemDto dto;
		[Inject]
		private GarageSaleItemService Service { get; set; }

		protected async override Task OnInitializedAsync()
		{
			dto = await Service.GetByIdAsync(Id);
		}

		private async void HandleValidSubmit()
		{
			dto = await Service.UpdateAsync(dto);
			StateHasChanged();
		}
	}
}
