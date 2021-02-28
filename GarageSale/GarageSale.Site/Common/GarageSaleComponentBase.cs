using GarageSale.Shared.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageSale.Site.Common
{
	public class GarageSaleComponentBase<T> : ComponentBase
	{
		[Inject]
		public GarageSaleItemService Service { get; set; }
		[Inject]
		public NavigationManager Navigation { get; set; }
		public T Dto { get; set; }
	}
}
