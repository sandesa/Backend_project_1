﻿using System.ComponentModel.DataAnnotations;
using Webbshop.Models.Base;

namespace Webbshop.Models
{
	public class Product : BaseModel
	{
		public string Name { get; set; }
		public string Category { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageName { get; set; }

	}
}
