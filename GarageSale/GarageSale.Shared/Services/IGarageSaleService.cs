using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSale.Shared.Services
{
	public interface IGarageSaleService<T>
	{
		Task<T> GetByIdAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> CreateAsync(T entity);
		Task<T> UpdateAsync(T entity);
	}
}
