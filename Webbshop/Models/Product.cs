using System.ComponentModel.DataAnnotations;
using Webbshop.Models.Base;

namespace Webbshop.Models
{
	public class Product : BaseModel
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Category { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public string ImageName { get; set; }

	}
}
