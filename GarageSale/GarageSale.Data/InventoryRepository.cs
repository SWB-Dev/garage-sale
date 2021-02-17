using GarageSale.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GarageSale.Data
{
	public class InventoryRepository : IRepository<Inventory>
	{
		private readonly GarageSaleDbContext _dbContext;

		public InventoryRepository(GarageSaleDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Inventory> AddAsync(Inventory entity, CancellationToken cancellationToken = default)
		{
			await _dbContext.Inventory.AddAsync(entity, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return entity;
		}

		public async Task<bool> DeleteAsync(Inventory entity, CancellationToken cancellationToken = default)
		{
			_dbContext.Inventory.Remove(entity);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return true;
		}

		public async Task<IEnumerable<Inventory>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return await _dbContext.Inventory.Include(i => i.Item).Where(i => i.Item.IsForSale).ToListAsync(cancellationToken);
		}

		public async Task<Inventory> GetByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			var keys = new object[] { id };
			return await _dbContext.Inventory.FindAsync(keys, cancellationToken);

		}

		public async Task UpdateAsync(Inventory entity, CancellationToken cancellationToken = default)
		{
			_dbContext.Update(entity);
			await _dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
