using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webbshop.Data;
using Webbshop.Migrations;
using Webbshop.Models;

namespace Webbshop.Controllers
{
	[Route("/api")]
	[ApiController]
	public class APIController : ControllerBase
	{
		private readonly AppDbContext database;

		public APIController(AppDbContext database)
		{
			this.database = database;
		}

		[HttpGet]
		public async Task<ActionResult<List<Product>>> GetProducts()
		{
			return await database.Products.ToListAsync();
		}
	}
}
