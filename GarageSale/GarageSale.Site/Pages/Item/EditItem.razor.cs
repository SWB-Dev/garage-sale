﻿using GarageSale.Shared.ItemDtos;
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

		protected async override Task OnInitializedAsync()
		{
			Dto = await Service.GetByIdAsync(Id);
		}

		private async void HandleValidSubmit()
		{
			Dto = await Service.UpdateAsync(Dto);
			StateHasChanged();
		}
	}
}
