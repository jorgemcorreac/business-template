using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure.Data
{
	public interface IStockContext : IDisposable
	{
		Guid ScopeId { get; }
		DbSet<User> Users { get; set; }
		DbSet<Product> Products { get; set; }
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		int SaveChanges();
		Task<int> SaveChangesAsync();
	}
}