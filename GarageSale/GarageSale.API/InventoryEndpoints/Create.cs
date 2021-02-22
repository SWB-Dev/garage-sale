using GarageSale.API.ItemEndpoints;
using GarageSale.Data;
using GarageSale.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GarageSale.API.InventoryEndpoints
{
	[ApiController]
	public class Create : ControllerBase
	{
		private readonly InventoryRepository _repo;

		public Create(InventoryRepository repo)
		{
			_repo = repo;
		}

		[HttpPost]
		[Route("/api/inventory/create")]
		public async Task<ActionResult<InventoryDto>> CreateAsync([FromBody] InventoryDto dto, CancellationToken cancellationToken)
		{
			var itemDto = dto.Item;

			var item = itemDto.MapItem();


			var inventory = new Inventory
			{
				Quantity = dto.Quantity,
				UnitPrice = dto.UnitPrice,
				Item = item
			};

			inventory = await _repo.AddAsync(inventory, cancellationToken);

			return Ok(inventory);
		}
	}
}
