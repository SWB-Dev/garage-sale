using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSale.Data.Entities
{
	public class Item : BaseEntity, IDbMutable
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsForSale { get; set; }
		public string ImageUrl { get; set; }
	}
}
