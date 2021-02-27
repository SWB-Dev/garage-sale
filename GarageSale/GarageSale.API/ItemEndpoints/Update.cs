using GarageSale.Data;
using GarageSale.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageSale.API.ItemEndpoints
{
	public class Update : GarageSaleControllerBase<Item>
	{
		public Update(IRepository<Item> repo) : base(repo)
		{
		}

		[HttpPatch]
		[Route("/api/item/update")]
		public async Task<ActionResult<ItemDto>> UpdateAsync([FromBody] ItemDto dto)
		{
			var item = await _repo.GetByIdAsync(dto.Id);

			if (item is null) return BadRequest();

			item.UpdateItem(dto);

			await _repo.UpdateAsync(item);

			return Ok(dto);
		}
	}
}
