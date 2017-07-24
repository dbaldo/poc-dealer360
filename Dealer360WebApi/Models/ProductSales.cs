using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dealer360WebApi.Models
{
	public class ProductSales
	{
		[Key]
		public string Id { get; set; }

		public string Name { get; set; }
		public string Category { get; set; }

		public int QtdSalesMonthly  { get; set; }
		public int QtdSalesYearly { get; set; }
	}
}