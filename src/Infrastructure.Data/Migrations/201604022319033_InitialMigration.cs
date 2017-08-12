using System.Data.Entity.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Products",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 20),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        UnitsInStock = c.Short(),
                        Discontinued = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);

            CreateTable(
                    "dbo.Users",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 100),
                        Birthdate = c.DateTime(false, storeType: "date")
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
        }

        public override void Down()
        {
            DropIndex("dbo.Users", new[] {"Name"});
            DropIndex("dbo.Products", new[] {"Name"});
            DropTable("dbo.Users");
            DropTable("dbo.Products");
        }
    }
}