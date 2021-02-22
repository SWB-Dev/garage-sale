using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageSale.API.ItemEndpoints
{
	public class ItemDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsForSale { get; set; }
		public string ImageUrl { get; set; }
	}
}
