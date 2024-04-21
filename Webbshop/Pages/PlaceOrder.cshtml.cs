using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webbshop.Pages
{
    public class PlaceOrderModel : PageModel
    {
        public decimal TotalCost { get; set; }
        public void OnGet()
        {
            string totalCostString = TempData["TotalCostCheckout"] as string;

            TotalCost = decimal.Parse(totalCostString);
        }
    }
}
