using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GarageSale.Data
{
	public interface IRepository<T> where T : BaseEntity, IDbMutable
	{
		Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
		Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
		Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
		Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
		Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default);
		Task<T> GetFilteredSingleAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
	}
}
