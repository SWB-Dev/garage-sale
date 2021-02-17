using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSale.Data.Entities
{
	public class OrderItemDetail
	{
		public int ItemId { get; set; }
		public string ItemName { get; set; }
		public string ItemImageUrl { get; set; }

		public OrderItemDetail(int itemId, string itemName, string itemImageUrl)
		{
			ItemId = itemId;
			ItemName = itemName;
			ItemImageUrl = itemImageUrl;
		}
	}
}
