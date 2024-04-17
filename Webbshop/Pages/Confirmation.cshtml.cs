using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webbshop.Pages
{
    public class ConfirmationModel : PageModel
    {
        public decimal TotalCost { get; set; }

        public void OnGet()
        {
            string totalCostString = TempData["TotalCost"] as string;

            TotalCost = decimal.Parse(totalCostString);
        }
    }

}
