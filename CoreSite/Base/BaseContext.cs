using System.Threading.Tasks;
using CoreSite.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoreSite.Base
{
	public abstract class BaseContext : DbContext, IContext
	{
		private string ConnectionString { get; set; }
		
		public BaseContext(string connection) : base()
		{
			this.ConnectionString = connection;
			
			this.ChangeTracker.Tracked += BaseContextHelper.OnObjectMaterialized;
		}

		public BaseContext(DbContextOptions options) : base(options)
		{
			// For testing?
			//this.ChangeTracker.Tracked += this.OnObjectMaterialized;
		}
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//base.OnConfiguring(optionsBuilder);

			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(this.ConnectionString);
			}
		}
		// For testing?
		//public new void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
			// If not configured when constructed set to use Sql server.
			//if (!optionsBuilder.IsConfigured && !string.IsNullOrEmpty(this.ConnectionName))
			//{
			//	string connection = null;// ConfigurationManager.ConnectionStrings[this.ConnectionName].ConnectionString;

			//	optionsBuilder.UseSqlServer(connection);
			//}
			//base.OnConfiguring(optionsBuilder);

			//this.ChangeTracker.Tracked += this.OnObjectMaterialized;
		//}
		
		public void ApplyChanges<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
		{
			this.Set<TEntity>().Add(entity);
			
			BaseContextHelper.ApplyChanges(this.ChangeTracker);
		}

		public void SyncChangeTracking()
		{
			foreach(var entry in this.ChangeTracker.Entries<IBaseEntity>())
			{
				entry.Entity.ModelState = ModelState.Unchanged;

				var originalValues = BaseContextHelper.BuildOriginalValues(entry.Entity.GetType(), this.Entry(entry.Entity).OriginalValues);

				entry.Entity.SetOriginalValues(originalValues);
			}
		}

		public async Task<int> SaveChangesAsync()
		{
			return await base.SaveChangesAsync();
		}
	}
}