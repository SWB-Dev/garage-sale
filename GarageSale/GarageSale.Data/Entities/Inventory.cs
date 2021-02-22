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
		public decimal UnitPrice { get; set; }

		public Inventory()
		{

		}

		public Inventory(Item item, int quantity, decimal unitPrice)
		{
			Item = item;
			Quantity = quantity;
			UnitPrice = unitPrice;
		}
	}
}
