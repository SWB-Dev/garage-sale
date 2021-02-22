using GarageSale.Data;
using GarageSale.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GarageSale.API.ItemEndpoints
{
	public class GetFiltered : GarageSaleControllerBase<Item>
	{
		public GetFiltered(IRepository<Item> repo) : base(repo)
		{
		}

		[HttpGet]
		[Route("/api/item/filtered/")]
		public async Task<ActionResult<List<ItemDto>>> GetFilteredAsync([FromQuery]ItemFilterCriteria criteria, CancellationToken cancellationToken)
		{
			//Expression<Func<Item, bool>> filter = i => i.IsForSale;

			var filterCriteria = new FilterCritiera<Item>(criteria.Field, criteria.Value);
			var filter = filterCriteria.Filter(criteria.Operation);

			var item = await _repo.GetFilteredSingleAsync(filter, cancellationToken);
			if (item is null)
				return NotFound();
			return new List<ItemDto>() { item.MapDto() };
		}
	}

	public class ItemFilterCriteria
	{
		public string Field { get; set; }
		public string Operation { get; set; }
		public string Value { get; set; }
	}
}
