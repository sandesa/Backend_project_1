using Webbshop.Models.Base;

namespace Webbshop.Models
{
    public class OrderItem : BaseModel
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

    }
}
