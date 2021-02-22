using GarageSale.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageSale.API
{
	[ApiController]
	public abstract class GarageSaleControllerBase<T> : ControllerBase where T : BaseEntity, IDbMutable
	{
		protected readonly IRepository<T> _repo;
		public Func<T, bool> _filter;

		public GarageSaleControllerBase(IRepository<T> repo)
		{
			_repo = repo;
		}
	}
}
