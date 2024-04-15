using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Webbshop.Data;
using Webbshop.Models;

namespace Webbshop.Pages
{
	public class IndexModel : PageModel
	{
		private readonly AppDbContext database;

		public IndexModel(AppDbContext database)
		{
			this.database = database;
		}

		public List<Product> Products { get; set; } = new();
		public async Task OnGetAsync() =>
			Products = await database.Products.ToListAsync();
	}
}