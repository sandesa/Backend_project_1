using Webbshop.Models;

namespace Webbshop.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        ICollection<Product> GetProducts(int? page, string? name, string? category);

        Product GetProduct(string img);
        bool ProductExists(string img);
    }
}
