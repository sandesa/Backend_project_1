using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Webbshop.Data;
using Webbshop.Models;
using Microsoft.EntityFrameworkCore;

namespace Webbshop.Pages
{
    public class OrderModel : PageModel
    {
        private readonly AppDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public OrderModel(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Product Product { get; set; }

        [BindProperty, Range(1, int.MaxValue, ErrorMessage = "You must order at least one item")]
        public int Quantity { get; set; } = 1;

        [BindProperty]
        public decimal Price { get; set; }

        public async Task OnGetAsync()
        {
            Product = await context.Products.FindAsync(Id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var accessControl = new AccessControl(context, httpContextAccessor);
                var accId = accessControl.GetLoggedInAccountId();

                var existingBasket = await context.Baskets 
                                     .Include(b => b.Items)
                                     .FirstOrDefaultAsync(b => b.AccountId == accId);

                Product = await context.Products.FindAsync(Id);
                Price = Product.Price;

                if (existingBasket != null)
                {
                    var existingItem = existingBasket.Items.Find(p => p.ProductId == Id);
                    if(existingItem != null)
                    {
                        existingItem.Quantity += Quantity;
                    }
                    else
                    {
                        existingBasket.Items.Add(new OrderItem
                        {
                            ProductId = Id,
                            UnitPrice = Price,
                            Quantity = Quantity,
                        });
                    }
                }
                else
                {
                    Basket basket = new()
                    {
                        AccountId = accId,
                        Items = new List<OrderItem>
                        {
                            new() {
                                ProductId = Id,
                                UnitPrice = Price,
                                Quantity = Quantity
                            }
                        }
                    };
                    context.Baskets.Add(basket);
                }

                await context.SaveChangesAsync();

                string confirmation = "The item has been added to your cart!";
                TempData["Confirmation"] = confirmation;

                decimal totalCost = Quantity * Price;
                TempData["TotalCost"] = totalCost.ToString();

                return RedirectToPage("/Confirmation");
            }
            Product = await context.Products.FindAsync(Id);
            return Page();
        }
    }
}
