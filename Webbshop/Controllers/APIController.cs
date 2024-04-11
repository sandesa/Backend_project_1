using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webbshop.Data;

namespace Webbshop.Controllers
{
	[Route("/api")]
	[ApiController]
	public class APIController : ControllerBase
	{
		private readonly AppDbContext database;

		public APIController(AppDbContext database)
		{
			this.database = database;
		}
	}
}
