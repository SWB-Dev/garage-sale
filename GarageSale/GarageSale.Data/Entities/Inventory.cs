using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSale.Data.Entities
{
	public class Inventory : BaseEntity, IDbMutable
	{
		public Item Item { get; set; }
		public int Quantity { get; set; }
	}
}
