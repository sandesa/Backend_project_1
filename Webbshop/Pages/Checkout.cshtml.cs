using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webbshop.Data;
using Webbshop.Models;

namespace Webbshop.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly AppDbContext context;
        public CheckoutModel(AppDbContext context)
        {
            this.context = context;
        }
        public Basket Basket { get; set; } = new();
        public List<Product> SelectedProducts { get; set; } = new();
    }
}
