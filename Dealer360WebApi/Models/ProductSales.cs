using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealer360WebApi.Models
{
	public class ProductSales
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }

		public int QtdSalesMonthly  { get; set; }
		public int QtdSalesYearly { get; set; }
	}
}