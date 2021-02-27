using GarageSale.Data;
using GarageSale.Data.Entities;
using GarageSale.Shared.ItemDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GarageSale.API.ItemEndpoints
{
	public class GetById : GarageSaleControllerBase<Item>
	{
		public GetById(IRepository<Item> repo) : base(repo)
		{
		}

		[HttpGet]
		[Route("/api/item/get/{id}")]
		public async Task<ActionResult<ItemDto>> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			var item = await _repo.GetByIdAsync(id, cancellationToken);

			if (item is null)
				return NotFound();

			var dto = new ItemDto
			{
				 Id = item.Id,
				 Name = item.Name,
				 Description = item.Description,
				 ImageUrl = item.ImageUrl,
				 IsForSale = item.IsForSale
			};

			return Ok(dto);
		}
	}
}
