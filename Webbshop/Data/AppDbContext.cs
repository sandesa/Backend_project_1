using Microsoft.EntityFrameworkCore;
using Webbshop.Models;

namespace Webbshop.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Account> Accounts { get; set; }
		public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }


        internal object Findasync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
