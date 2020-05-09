using System;
using System.Threading.Tasks;

namespace CoreSite.Base.Interfaces
{
	public interface IRepository : IDisposable
    {
		void ApplyChanges<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

		Task<int> SaveChangesAsync(bool syncChangeTracking = true);
    }
}