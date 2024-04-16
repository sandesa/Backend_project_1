using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Webbshop.Data;
using Webbshop.Models;

namespace Webbshop.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly AppDbContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CheckoutModel(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public Basket Basket { get; set; }
        public List<Product> SelectedProducts { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            var accessControl = new AccessControl(context, _httpContextAccessor);
            var accId = accessControl.GetLoggedInAccountId();

            Basket = await context.Baskets.Include(b => b.Items).FirstOrDefaultAsync(b => b.AccountId == accId);

            if (Basket != null && Basket.NumberOfItems > 0)
            {
                var productIds = Basket.Items.Select(item => item.ProductId).ToList();
                SelectedProducts = await context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
            }
        }
    }
}
