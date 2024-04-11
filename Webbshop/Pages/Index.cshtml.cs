using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webbshop.Data;

namespace Webbshop.Pages
{
	public class IndexModel : PageModel
	{
		private readonly AppDbContext database;

		public IndexModel(AppDbContext database)
		{
			this.database = database;
		}

		public void OnGet()
		{

		}
	}
}