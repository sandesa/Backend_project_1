using Webbshop.Models.Base;

namespace Webbshop.Models
{
    public class Basket : BaseModel
    {
        public List<OrderItem> Items { get; set; } = new();
        public int NumberOfItems => Items.Sum(x => x.Quantity);
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
