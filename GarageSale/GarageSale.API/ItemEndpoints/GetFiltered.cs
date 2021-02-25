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
		// api/item/filtered?criteria[0].Field=Description&criteria[0].Operation=Contains&criteria[0].Value=er&criteria[1].Field=Name&criteria[1].Operation=Contains&criteria[1].Value=str
		public async Task<ActionResult<List<ItemDto>>> GetFilteredAsync([FromQuery]List<ItemFilterCriteria> criteria, CancellationToken cancellationToken)
		{
			//Expression<Func<Item, bool>> filter = i => i.IsForSale;
			List<Expression<Func<Item, bool>>> filters = new List<Expression<Func<Item, bool>>>();

			foreach (var c in criteria)
			{
				var filterCriteria = new FilterCritiera<Item>(c.Field, c.Value);
				filters.Add(filterCriteria.Filter(c.Operation));
			}
			//var filterCriteria = new FilterCritiera<Item>(criteria.Field, criteria.Value);
			//var filter = filterCriteria.Filter(criteria.Operation);

			List<Item> items = new List<Item>();

			foreach (var f in filters)
			{
				var item = await _repo.GetFilteredSingleAsync(f, cancellationToken);
				if (item is not null)
				{
					items.Add(item);
				}
			}

			//filters.ForEach(async f => { 
			//	var item = await _repo.GetFilteredSingleAsync(f, cancellationToken);
			//	if (item is not null)
			//		items.Add(item);
			//});

			//var item = await _repo.GetFilteredSingleAsync(filter, cancellationToken);
			if (!items.Any())
				return NotFound();
			return items.Select(i => i.MapDto()).ToList(); 
		}

		[HttpGet]
		[Route("/api/item/filtered/single/")]
		public async Task<ActionResult<List<ItemDto>>> GetFilteredAsync([FromQuery] ItemFilterCriteria criteria, CancellationToken cancellationToken)
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
