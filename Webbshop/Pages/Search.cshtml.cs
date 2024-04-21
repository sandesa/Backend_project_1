using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webbshop.Data;
using Webbshop.Models;

namespace Webbshop.Pages
{
    public class SearchModel : PageModel
    {
        private readonly AppDbContext context;

        public SearchModel(AppDbContext context) => this.context = context;

        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? PageNum { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<Product> Products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? pageNum)
        {
            IQueryable<Product> products = context.Products;

            if (!string.IsNullOrEmpty(Search))
            {
                products = products.Where(p => p.Name.Contains(Search));
            }

            if (!string.IsNullOrEmpty(Filter))
            {
                products = products.Where(p => p.Category.Contains(Filter));
            }

            int totalProducts = products.Count();

            TotalPages = (int)Math.Ceiling((double)totalProducts / 10);

            CurrentPage = pageNum ?? 1;

            Products = products.Distinct().OrderBy(p => p.Category).ToList();

            Products = Products
                .Skip((CurrentPage - 1) * 10)
                .Take(10)
                .ToList();

            return Page();
        }
    }
}
