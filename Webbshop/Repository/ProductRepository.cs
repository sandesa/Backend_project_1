using Webbshop.Data;
using Webbshop.Interfaces;
using Webbshop.Models;

namespace Webbshop.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext contex;

        public ProductRepository(AppDbContext contex) 
        {
            this.contex = contex;
        }

        public Product GetProduct(int id)
        {
            return contex.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Product> GetProducts()
        {
            return contex.Products.OrderBy(p => p.Category).Take(10).ToList();
        }

        public ICollection<Product> GetProducts(int? page, string? name, string? category)
        {
            IQueryable<Product> products = contex.Products;

            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category.Contains(category));
            }

            if (page == null)
            {
                return products.Distinct().OrderBy(p => p.Category).Take(10).ToList();
            }

            return products.Distinct().OrderBy(p => p.Category)
                            .Skip(((int)page - 1) * 10)
                            .Take(10)
                            .ToList();
        }

        public bool ProductExists(int id)
        {
            return contex.Products.Any(p => p.Id == id);
        }
    }
}
