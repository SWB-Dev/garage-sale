using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSale.Data.Entities
{
	public class Order : BaseEntity, IDbMutable
	{
		public Order()
		{

		}

		public Order(string buyerName, List<OrderItem> items)
		{
			BuyerName = buyerName;
			OrderItems = items;
		}
		public string BuyerName { get; set; }
		public IEnumerable<OrderItem> OrderItems { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal Total()
		{
			var total = 0m;

			foreach (var item in OrderItems)
			{
				total += item.Price;
			}

			return total;
		}
	}
}
