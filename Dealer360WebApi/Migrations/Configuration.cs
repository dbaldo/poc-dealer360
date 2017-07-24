namespace Dealer360WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dealer360WebApi.Models.SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Dealer360WebApi.Models.SalesContext";
        }

        protected override void Seed(Dealer360WebApi.Models.SalesContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//

			context.ProductSales.AddOrUpdate(x => x.Id,
				new Models.ProductSales { Id = "1", Category = "4W", Name = "City", QtdSalesMonthly = 200, QtdSalesYearly = 1000 },
				new Models.ProductSales { Id = "2", Category = "4W", Name = "Fit", QtdSalesMonthly = 530, QtdSalesYearly = 3000 },
				new Models.ProductSales { Id = "3", Category = "2W", Name = "CG Fan 160", QtdSalesMonthly = 400, QtdSalesYearly = 6000 },
				new Models.ProductSales { Id = "4", Category = "2W", Name = "SH150i", QtdSalesMonthly = 300, QtdSalesYearly = 6000 }
				);
		}
    }
}
