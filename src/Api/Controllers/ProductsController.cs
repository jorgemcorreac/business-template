using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Domain;
using Infrastructure.Crosscutting.Core.Logging;
using Infrastructure.Data;

namespace Api.Controllers
{
	/// <summary>
	///     Products Service
	/// </summary>
	public class ProductsController : ApiController
	{
		private readonly IStockContext _ctx;
		private readonly ILogger _log = LoggerFactory.CreateLog();

		/// <summary>
		/// </summary>
		/// <param name="ctx"></param>
		public ProductsController(IStockContext ctx)
		{
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
		}

		// GET: api/Products
		/// <summary>
		///     Get all products
		/// </summary>
		/// <returns></returns>
        public async Task<IEnumerable<Product>> GetProducts() => await _ctx.Products.ToListAsync();

        // GET: api/Products/5
        /// <summary>
        ///     Get a product by id
        /// </summary>
        /// <param name="id">The product id</param>
        /// <returns></returns>
        [ResponseType(typeof (Product))]
		public async Task<IHttpActionResult> GetProduct(int id)
		{
			throw new ObjectNotFoundException("Exception to test the overall exception handling");

			var product = await _ctx.Products.FindAsync(id);

			if (product == null)
				return NotFound();

			return Ok(product);
		}

		// PUT: api/Products/5
		/// <summary>
		///     Update a the product
		/// </summary>
		/// <param name="id">The product id</param>
		/// <param name="product">The product entity</param>
		/// <returns></returns>
		[ResponseType(typeof (void))]
		public async Task<IHttpActionResult> PutProduct(int id, Product product)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (id != product.Id)
				return BadRequest();

			_ctx.Entry(product).State = EntityState.Modified;

			try
			{
				await _ctx.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				if (!ProductExists(id))
					return NotFound();

				_log.Error("An error occurred while trying to update a product", ex);
				throw;
			}
			catch (DbUpdateException ex)
			{
				if (ProductExists(product.Name))
					return BadRequest("Unable to update this product, another product exist with the same name");

				_log.Error("An error occurred while trying to update a product", ex);
				throw;
			}

			_log.Info("A product has been updated");
			return StatusCode(HttpStatusCode.NoContent);
		}

		// POST: api/Products
		/// <summary>
		///     Create a new product
		/// </summary>
		/// <param name="product">The product entity</param>
		/// <returns></returns>
		[ResponseType(typeof (Product))]
		public async Task<IHttpActionResult> PostProduct(Product product)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (ProductExists(product.Name))
				return BadRequest("Unable to create this product, another product exist with the same name");

			_ctx.Products.Add(product);
			await _ctx.SaveChangesAsync();

			_log.Info("A product has been created");
			return CreatedAtRoute("DefaultApi", new {id = product.Id}, product);
		}

		// DELETE: api/Products/5
		/// <summary>
		///     Delete a product by id
		/// </summary>
		/// <param name="id">The product id</param>
		/// <returns></returns>
		[ResponseType(typeof (Product))]
		public async Task<IHttpActionResult> DeleteProduct(int id)
		{
			var product = await _ctx.Products.FindAsync(id);
			if (product == null)
				return NotFound();

			_ctx.Products.Remove(product);
			await _ctx.SaveChangesAsync();

			_log.Info("A product has been deleted");
			return Ok(product);
		}

		/// <summary>
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing)

		{
			if (disposing)
				_ctx.Dispose();

			base.Dispose(disposing);
		}

		private bool ProductExists(int id) => _ctx.Products.Any(e => e.Id == id);

		private bool ProductExists(string name) => _ctx.Products.Any(e => e.Name == name);
	}
}