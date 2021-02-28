using GarageSale.Shared.ItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GarageSale.Shared.Services
{
	public class GarageSaleItemService : IGarageSaleService<ItemDto>
	{
		public HttpClient Client { get; }
		private const string MEDIATYPE = "application/json";
		public bool IsFetchingData { get; set; } = false;

		public GarageSaleItemService(HttpClient client)
		{
			client.BaseAddress = new Uri("https://localhost:5011/api/item/");

			Client = client;
		}

		public async Task<ItemDto> CreateAsync(ItemDto entity)
		{
			string json = JsonSerializer.Serialize<ItemDto>(entity);
			var content = new StringContent(json, Encoding.UTF8, MEDIATYPE);
			var dto = await Client.PostAsync("create", content)
				.Result.Content.ReadFromJsonAsync<ItemDto>();

			return dto;
		}

		public async Task<IEnumerable<ItemDto>> GetAllAsync()
		{
			IsFetchingData = true;
			List<ItemDto> dtos = new List<ItemDto>();
			var response = await Client.GetAsync("");
			if (response.IsSuccessStatusCode)
			{
				dtos = await response.Content.ReadFromJsonAsync<List<ItemDto>>();
			}
			IsFetchingData = false;
			return dtos;

		}

		public async Task<ItemDto> GetByIdAsync(int id)
		{
			var dto = await Client.GetAsync($"get/{id}")
				.Result.Content.ReadFromJsonAsync<ItemDto>();

			return dto;
		}

		public async Task<ItemDto> UpdateAsync(ItemDto entity)
		{
			throw new NotImplementedException();
		}
	}
}
