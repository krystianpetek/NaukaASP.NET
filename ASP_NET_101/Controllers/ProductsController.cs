using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_NET_101.Pages.Services;
using ASP_NET_101.Models;
using System.Collections.Generic;

namespace ASP_NET_101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public JsonFileProductService ProductService { get; }
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        } 
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string ProductID, [FromQuery]int Rating)
        {
            ProductService.AddRating(ProductID, Rating);
            return Ok();
        }
    }
}
