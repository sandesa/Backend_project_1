using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Webbshop.Models;

namespace Webbshop.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Product> Products { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}
	}
}
