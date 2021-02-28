using GarageSale.Data;
using GarageSale.Data.Entities;
using GarageSale.Shared.ItemDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageSale.API.ItemEndpoints
{
	public class GetAll : GarageSaleControllerBase<Item>
	{
		public GetAll(IRepository<Item> repo) : base(repo)
		{
		}

		[HttpGet]
		[Route("/api/item")]
		public async Task<ActionResult<List<ItemDto>>> GetAllAsync()
		{
			var items = await _repo.GetAllAsync();

			if (items is null) return NotFound();

			var dtos = items.Select(i => i.MapDto()).ToList();

			return Ok(dtos);
		}
	}
}
