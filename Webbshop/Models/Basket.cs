namespace Webbshop.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public int NumberOfItems => Items.Sum(x => x.Quantity);
    }
}
