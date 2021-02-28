using GarageSale.Shared.ItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageSale.Site.Pages.Item
{
	public partial class CreateItem
	{
		protected override async Task OnInitializedAsync()
		{
			Dto = new ItemDto();
		}
		private async void HandleValidSubmit()
		{
			Dto = await Service.CreateAsync(Dto);
			if(Dto is null)
			{
				StateHasChanged();
			}
			else
			{
				Navigation.NavigateTo($"/garage-sale/items/{Dto.Id}");
			}
			
		}
	}
}
