namespace Infrastructure.Data.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	public partial class InitialMigration : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Products",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					Name = c.String(nullable: false, maxLength: 20),
					UnitPrice = c.Decimal(precision: 18, scale: 2),
					UnitsInStock = c.Short(),
					Discontinued = c.Boolean(nullable: false)
				})
				.PrimaryKey(t => t.Id)
				.Index(t => t.Name, unique: true);

			CreateTable(
				"dbo.Users",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					Name = c.String(nullable: false, maxLength: 100),
					Birthdate = c.DateTime(nullable: false, storeType: "date")
				})
				.PrimaryKey(t => t.Id)
				.Index(t => t.Name, unique: true);

		}

		public override void Down()
		{
			DropIndex("dbo.Users", new[] { "Name" });
			DropIndex("dbo.Products", new[] { "Name" });
			DropTable("dbo.Users");
			DropTable("dbo.Products");
		}
	}
}
