using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Webbshop.Data;
using Webbshop.Models;

namespace Webbshop.Pages
{
    public class SearchModel : PageModel
    {
        private readonly AppDbContext context;
        private const int PerPage = 10;

        public SearchModel(AppDbContext context)
        {
            this.context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string FilterString { get; set; } = string.Empty;

        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; }

        public List<Product> SearchedProducts { get; set; }

        public void OnGet(int? page)
        {
            IQueryable<Product> products = context.Products;

            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(p => p.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(FilterString))
            {
                products = products.Where(p => p.Category.Contains(FilterString));
            }

            int totalProducts = products.Count();

            TotalPages = (int)Math.Ceiling((double)totalProducts / PerPage);

            CurrentPage = page ?? 1;
            CurrentPage = Math.Max(1, Math.Min(TotalPages, CurrentPage));

            SearchedProducts = products
                .Skip((CurrentPage - 1) * PerPage)
                .Take(PerPage)
                .ToList();
        }
    }
}
