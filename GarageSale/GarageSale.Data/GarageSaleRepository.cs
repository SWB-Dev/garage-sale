using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GarageSale.Data
{
	public class GarageSaleRepository<T> : IRepository<T> where T : BaseEntity, IDbMutable
	{
		private readonly GarageSaleDbContext _dbContext;
		public GarageSaleRepository(GarageSaleDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
		{
			await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return entity;
		}

		public async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default)
		{
			_dbContext.Set<T>().Remove(entity);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return true;
		}

		public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return await _dbContext.Set<T>().ToListAsync(cancellationToken);
		}

		public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			var keys = new object[] { id };
			return await _dbContext.Set<T>().FindAsync(keys, cancellationToken);
		}

		public async Task<T> GetFilteredSingleAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
		{
			return await _dbContext.Set<T>().FirstOrDefaultAsync(filter, cancellationToken);
		}

		public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
		{
			_dbContext.Set<T>().Update(entity);
			await _dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
