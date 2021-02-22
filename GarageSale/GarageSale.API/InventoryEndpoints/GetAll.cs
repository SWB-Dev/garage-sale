using GarageSale.API.ItemEndpoints;
using GarageSale.Data;
using GarageSale.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GarageSale.API.InventoryEndpoints
{
	[ApiController]
	public class GetAll : ControllerBase
	{
		private readonly InventoryRepository _repo;

		public GetAll(InventoryRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		[Route("/api/inventory/get")]
		public async Task<ActionResult<List<InventoryDto>>> GetAllAsync(CancellationToken cancellationToken)
		{
			var inventory = await _repo.GetAllAsync(cancellationToken);

			var items = inventory.Select(i => new InventoryDto
			{
				Id = i.Id,
				Item = new ItemDto { Id = i.Item.Id, Name = i.Item.Name, Description = i.Item.Description, ImageUrl = i.Item.ImageUrl, IsForSale = i.Item.IsForSale },
				Quantity = i.Quantity,
				UnitPrice = i.UnitPrice
			}).ToList();

			return Ok(items);
		}
	}
}
