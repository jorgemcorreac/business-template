using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using Domain;
using Infrastructure.Crosscutting.Core.Logging;

namespace Infrastructure.Data
{
	public class StockContext : DbContext, IStockContext
	{
		private readonly ILogger _log;

		public StockContext()
		{
			ScopeId = Guid.NewGuid();
			_log = LoggerFactory.CreateLog(GetType());
			Configuration.ProxyCreationEnabled = false;
			Configuration.LazyLoadingEnabled = false;
		}

		public virtual DbSet<User> Users { get; set; }

		public Guid ScopeId { get; }
		public virtual DbSet<Product> Products { get; set; }

		public override Task<int> SaveChangesAsync()
		{
			try
			{
				var saveChangesAsync = base.SaveChangesAsync();

				_log?.Info("Asynchronous changes saved successfully");

				return saveChangesAsync;
			}
			catch (DbEntityValidationException ex)
			{
				foreach (var validationErrors in ex.EntityValidationErrors)
					foreach (var validationError in validationErrors.ValidationErrors)
						_log?.Error("Property: {0} Error: {1}", ex, validationError.PropertyName, validationError.ErrorMessage);
				throw;
			}
		}

		public override int SaveChanges()
		{
			try
			{
				var saveChanges = base.SaveChanges();

				_log?.Info("Changes saved successfully");

				return saveChanges;
			}
			catch (DbEntityValidationException ex)
			{
				foreach (var validationErrors in ex.EntityValidationErrors)
					foreach (var validationError in validationErrors.ValidationErrors)
						_log?.Error("Property: {0} Error: {1}", ex, validationError.PropertyName, validationError.ErrorMessage);
				throw;
			}
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Entity<User>()
				.Property(e => e.Birthdate)
				.HasColumnType("date");
			modelBuilder.Entity<User>()
				.Property(e => e.Name)
				.HasColumnAnnotation(IndexAnnotation.AnnotationName,
					new IndexAnnotation(
						new IndexAttribute($"IX_{nameof(Product.Name)}")
						{
							IsUnique = true
						}));

			modelBuilder.Entity<Product>()
				.Property(e => e.Name)
				.HasColumnAnnotation(IndexAnnotation.AnnotationName,
					new IndexAnnotation(
						new IndexAttribute($"IX_{nameof(Product.Name)}")
						{
							IsUnique = true
						}));

			base.OnModelCreating(modelBuilder);
		}
	}
}