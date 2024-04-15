using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webbshop.Models
{
    public class Basket
    {
        public List<OrderItem> Items { get; set; }
        public int NumberOfItems => Items.Sum(p => p.Quantity);
    }
}
