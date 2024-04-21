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

        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? PageNum { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<Product> Products { get; set; }

        public async Task<IActionResult> OnGetAsync(string search, string filter, int? pageNum)
        {
            try
            {
                var uRI = $"https://localhost:5000/api/results";

                if (!string.IsNullOrEmpty(search) || !string.IsNullOrEmpty(filter) || pageNum.HasValue)
                {
                    uRI += "?";

                    if (!string.IsNullOrEmpty(search))
                        uRI += $"search={search}";

                    if (!string.IsNullOrEmpty(filter))
                        uRI += $"&filter={filter}";

                    if (pageNum.HasValue)
                    {
                        if (!string.IsNullOrEmpty(search) || !string.IsNullOrEmpty(filter))
                            uRI += "&";
                        uRI += $"page={pageNum}";
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

            int totalProducts = Products.Count;

            Products = Products.Skip((CurrentPage - 1) * 10).Take(10).ToList();

            TotalPages = (int)Math.Ceiling((double)totalProducts / 10);

            return Page();
        }
    }
}
