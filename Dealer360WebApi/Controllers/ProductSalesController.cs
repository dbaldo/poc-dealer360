using Dealer360WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace Dealer360WebApi.Controllers
{
	public class ProductSalesController : ODataController
	{
		private SalesContext db = new SalesContext();

		private bool ProductExists(string key)
		{
			return db.ProductSales.Any(p => p.Id == key);
		}

		[HttpGet]
		[EnableQuery(AllowedQueryOptions =System.Web.OData.Query.AllowedQueryOptions.All)]
		public IQueryable<ProductSales> Get()
		{
			//return (queryOpts.ApplyTo(db.ProductSales.AsQueryable()) as IQueryable<ProductSales>);
			return db.ProductSales.AsQueryable();
		}

		[HttpGet]
		[EnableQuery]
		public SingleResult<ProductSales> Get([FromODataUri] string key)
		{
			IQueryable<ProductSales> result = db.ProductSales.Where(p => p.Id == key);
			return SingleResult.Create(result);
		}

		[HttpPost]
		public async Task<IHttpActionResult> Post(ProductSales product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.ProductSales.Add(product);
			await db.SaveChangesAsync();
			return Created(product);
		}

		[HttpPatch]
		public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<ProductSales> product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var entity = await db.ProductSales.FindAsync(key);
			if (entity == null)
			{
				return NotFound();
			}
			product.Patch(entity);
			try
			{
				await db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductExists(key))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return Updated(entity);
		}

		[HttpPut]
		public async Task<IHttpActionResult> Put([FromODataUri] string key, ProductSales update)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (key != update.Id)
			{
				return BadRequest();
			}
			db.Entry(update).State = EntityState.Modified;
			try
			{
				await db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductExists(key))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return Updated(update);
		}

		[HttpDelete]
		public async Task<IHttpActionResult> Delete([FromODataUri] string key)
		{
			var product = await db.ProductSales.FindAsync(key);
			if (product == null)
			{
				return NotFound();
			}
			db.ProductSales.Remove(product);
			await db.SaveChangesAsync();

			return StatusCode(HttpStatusCode.NoContent);
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}