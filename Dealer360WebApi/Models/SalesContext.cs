using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dealer360WebApi.Models
{
    public class SalesContext : DbContext
    {
        public SalesContext() 
                : base("name=SalesContext")
        {
        }
        public DbSet<ProductSales> ProductSales { get; set; }
    }
}