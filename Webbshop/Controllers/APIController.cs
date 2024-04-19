using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webbshop.Data;
using Webbshop.Migrations;
using Webbshop.Models;

namespace Webbshop.Controllers
{
	[Route("/api/products")]
	[ApiController]
	public class APIController : ControllerBase
	{
		private readonly AppDbContext database;

		public APIController(AppDbContext database)
		{
			this.database = database;
		}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string searchString, string filterString, int page = 1)
        //{
        //    IQueryable<Product> products = database.Products;

        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        products = products.Where(p => p.Name.Contains(searchString));
        //    }

        //    if (!string.IsNullOrEmpty(filterString))
        //    {
        //        products = products.Where(p => p.Category.Contains(filterString));
        //    }

        //    int pageSize = 10;
        //    int skip = (page - 1) * pageSize;

        //    var result = await products.Skip(skip).Take(pageSize).ToListAsync();
        //    return Ok(result);
        //}
    }
}
