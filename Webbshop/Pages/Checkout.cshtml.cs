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

        public Basket basket { get; set; }
        public List<Product> SelectedProducts { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            var accessControl = new AccessControl(_context, httpContextAccessor);
            var accId = accessControl.GetLoggedInAccountId();

            basket = await _context.Baskets.Include(b => b.Items).FirstOrDefaultAsync(b => b.AccountId == accId);

            if (basket != null && basket.NumberOfItems > 0)
            {
                var productIds = basket.Items.Select(item => item.ProductId).ToList();
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

        public async Task<IActionResult> OnPostAsync()
        {
            var accessControl = new AccessControl(_context, httpContextAccessor);
            var accId = accessControl.GetLoggedInAccountId();

            basket = await _context.Baskets.Include(b => b.Items).FirstOrDefaultAsync(b => b.AccountId == accId);

            if (ModelState.IsValid)
            {
                    var totalCostCheckout = basket.Items.Sum(p => p.Quantity * p.UnitPrice);
                    TempData["TotalCostCheckout"] = totalCostCheckout.ToString();

                    _context.RemoveRange(basket.Items);
                    await _context.SaveChangesAsync();
                
                return RedirectToPage("/PlaceOrder");
            }
            return Page();

        }
    }
}
