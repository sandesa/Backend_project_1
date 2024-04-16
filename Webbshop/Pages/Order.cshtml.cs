using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Webbshop.Data;
using Webbshop.Models;

namespace Webbshop.Pages
{
    public class OrderModel : PageModel
    {
        private AppDbContext context;
        public OrderModel(AppDbContext context) =>
            this.context = context;

		[BindProperty(SupportsGet = true)]
		public int Id { get; set; }
		public Product Product { get; set; }

        [BindProperty, Range(1, int.MaxValue, ErrorMessage = "You must order at least one item")]
        public int Quantity { get; set; } = 1;

        [BindProperty]
        public decimal Price { get; set; }
        public async Task OnGetAsync() =>
			Product = await context.Products.FindAsync(Id);
	}
}
