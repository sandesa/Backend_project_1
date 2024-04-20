using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Webbshop.Data;
using Webbshop.Models;

namespace Webbshop.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CheckoutModel(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public Basket Basket { get; set; }
        public List<Product> SelectedProducts { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            var accessControl = new AccessControl(_context, httpContextAccessor);
            var accId = accessControl.GetLoggedInAccountId();

            Basket = await _context.Baskets.Include(b => b.Items).FirstOrDefaultAsync(b => b.AccountId == accId);

            if (Basket != null && Basket.NumberOfItems > 0)
            {
                var productIds = Basket.Items.Select(item => item.ProductId).ToList();
                SelectedProducts = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostRemoveProductAsync(int itemId)
        {
            var accessControl = new AccessControl(_context, httpContextAccessor);
            var accId = accessControl.GetLoggedInAccountId();

            var basket = await _context.Baskets
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.AccountId == accId);

            if (basket != null)
            {
                var itemToRemove = basket.Items.FirstOrDefault(item => item.Id == itemId);
                if (itemToRemove != null)
                {
                    _context.Remove(itemToRemove);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("/Checkout");
        }

        public async Task<IActionResult> OnPostRemoveAllItemsAsync()
        {
            var accessControl = new AccessControl(_context, httpContextAccessor);
            var accId = accessControl.GetLoggedInAccountId();

            var basket = await _context.Baskets
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.AccountId == accId);

            if (basket != null)
            {
                _context.RemoveRange(basket.Items); 
                await _context.SaveChangesAsync(); 
            }

            return RedirectToPage("/Checkout");
        }
    }
}
