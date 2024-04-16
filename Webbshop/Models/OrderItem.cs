namespace Webbshop.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
    }
}
