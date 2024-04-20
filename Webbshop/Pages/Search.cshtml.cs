using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webbshop.Models;

namespace Webbshop.Pages
{
    public class SearchModel : PageModel
    {
        private readonly HttpClient httpClient;

        public SearchModel(HttpClient httpClient)
        {
            this.httpClient= httpClient;
        }

        [BindProperty]
        public string Filter { get; set; }

        [BindProperty]
        public string Search { get; set; }

        [BindProperty]
        public int? PageNum { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<Product> Products { get; set; }

        public async Task<IActionResult> OnGetAsync(string search, string filter, int? pageNum)
        {
            try
            {
                var uRI = $"https://localhost:5000/api";

                if(filter != null || search != null)
                {
                    uRI += $"/results?search={search}&filter={filter}";
                    
                    if(PageNum != null)
                    {
                        uRI += $"/results?page={pageNum}search={search}&filter={filter}";
                    }
                }

                var response = await httpClient.GetAsync(uRI);

                if (response.IsSuccessStatusCode)
                {
                    Products = await response.Content.ReadFromJsonAsync<List<Product>>();
                }
                else
                {
                    Products = new List<Product>();
                }
            }
            catch (Exception)
            {
                Products = new List<Product>();
            }

            CurrentPage = pageNum ?? 1;

            int totalProducts = Products.Count();

            TotalPages = (int)Math.Ceiling((double)totalProducts / 10);

            return Page();
        }
        
        public IActionResult OnPostPageIndex() 
        {
            return RedirectToPage(new { search = Search, filter = Filter, pageNum = PageNum });
        }
    }
}
