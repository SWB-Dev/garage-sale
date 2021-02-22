using GarageSale.Data;
using GarageSale.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GarageSale.API.ItemEndpoints
{
	[ApiController]
	public class Create : ControllerBase
	{
		private readonly IRepository<Item> _repo;

		public Create(IRepository<Item> repo)
		{
			_repo = repo;
		}
		[HttpPost]
		[Route("/api/item/create")]
		public async Task<ActionResult<ItemDto>> CreateAsync([FromBody] ItemDto dto, CancellationToken cancellationToken)
		{
			var item = new Item
			{
				Name = dto.Name,
				Description = dto.Description,
				ImageUrl = dto.ImageUrl,
				IsForSale = dto.IsForSale
			};

			item = await _repo.AddAsync(item, cancellationToken);

			dto.Id = item.Id;

			return Ok(dto);
		}
	}
}
