using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webbshop.Interfaces;
using Webbshop.Models;

namespace Webbshop.Controllers
{
    [AllowAnonymous]
    [Route("/api")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public APIController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(400)]
        public IActionResult GetProducts()
        {
            var products = productRepository.GetProducts();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(products);
        }

        [HttpGet("{imgName}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult GetProduct(string imgName)
        {
            if (!productRepository.ProductExists(imgName))
                return NotFound();

            var product = productRepository.GetProduct(imgName);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(product);
        }

        [HttpGet("/api/search")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(400)]
        public IActionResult GetProducts(int? page, string? search = null, string? filter = null)
        {
            var products = productRepository.GetProducts(page ,search, filter);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(products);
        }



    }
}
