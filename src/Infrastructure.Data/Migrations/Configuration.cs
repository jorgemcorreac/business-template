using System.Data.Entity.Migrations;
using Domain;

namespace Infrastructure.Data.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<StockContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(StockContext context)
		{
			//  This method will be called after migrating to the latest version.

			context.Products.AddOrUpdate(
			  p => p.Name,
			  new Product { Name = "Oculus Rift", UnitPrice = 600, UnitsInStock = 20 },
			  new Product { Name = "Google Cardboard", UnitPrice = 15, UnitsInStock = 1000},
			  new Product { Name = "View-Master", UnitPrice = 2.99m, Discontinued = true}
			);
		}
	}
}