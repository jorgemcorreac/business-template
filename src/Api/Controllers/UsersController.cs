using System;
using System.Collections.Generic;
using System.Data.Entity;
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
	///     Users Service
	/// </summary>
	public class UsersController : ApiController
	{
		private readonly IStockContext _ctx;
		private readonly ILogger _log = LoggerFactory.CreateLog();

		/// <summary>
		/// </summary>
		/// <param name="ctx"></param>
		public UsersController(IStockContext ctx)
		{
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
		}

		// GET: api/Users
		/// <summary>
		///     Get all users
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<User>> GetUsers() => await _ctx.Users.ToListAsync();

		// GET: api/Users/5
		/// <summary>
		///     Get a user by id
		/// </summary>
		/// <param name="id">The user id</param>
		/// <returns></returns>
		[ResponseType(typeof (User))]
		public async Task<IHttpActionResult> GetUser(int id)
		{
			var user = await _ctx.Users.FindAsync(id);
			if (user == null)
				return NotFound();

			return Ok(user);
		}

		// PUT: api/Users/5
		/// <summary>
		///     Update a the user
		/// </summary>
		/// <param name="id">The user id</param>
		/// <param name="user">The user entity</param>
		/// <returns></returns>
		[ResponseType(typeof (void))]
		public async Task<IHttpActionResult> PutUser(int id, User user)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (id != user.Id)
				return BadRequest();

			_ctx.Entry(user).State = EntityState.Modified;

			try
			{
				await _ctx.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				if (!UserExists(id))
					return NotFound();

				_log.Error("An error occurred while trying to update a user", ex);
				throw;
			}
			catch (DbUpdateException ex)
			{
				if (UserExists(user.Name))
					return BadRequest("Unable to update this user, another user exist with the same name");

				_log.Error("An error occurred while trying to update a user", ex);
				throw;
			}

			_log.Info("A user has been updated");
			return StatusCode(HttpStatusCode.NoContent);
		}


		// POST: api/Users
		/// <summary>
		///     Create a new user
		/// </summary>
		/// <param name="user">The user entity</param>
		/// <returns></returns>
		[ResponseType(typeof (User))]
		public async Task<IHttpActionResult> PostUser(User user)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (UserExists(user.Name))
				return BadRequest("Unable to create this user, another user exist with the same name");

			_ctx.Users.Add(user);
			await _ctx.SaveChangesAsync();

			_log.Info("A user has been created");
			return CreatedAtRoute("DefaultApi", new {id = user.Id}, user);
		}

		// DELETE: api/Users/5
		/// <summary>
		///     Delete a user by id
		/// </summary>
		/// <param name="id">The user id</param>
		/// <returns></returns>
		[ResponseType(typeof (User))]
		public async Task<IHttpActionResult> DeleteUser(int id)
		{
			var user = await _ctx.Users.FindAsync(id);
			if (user == null)
				return NotFound();

			_ctx.Users.Remove(user);
			await _ctx.SaveChangesAsync();

			_log.Info("A user has been deleted");
			return Ok(user);
		}

		/// <summary>
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_ctx.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool UserExists(int id) => _ctx.Users.Any(e => e.Id == id);

		private bool UserExists(string name) => _ctx.Users.Any(e => e.Name == name);
	}
}