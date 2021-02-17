using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSale.Data.Entities
{
	public class OrderItem : BaseEntity
	{
		public OrderItemDetail ItemDetails { get; set; }
		public decimal Price { get; set; }
	}
}
