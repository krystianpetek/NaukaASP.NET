using Microsoft.AspNetCore.Mvc;
using Lab2Buzowicz.Models;

namespace Lab2Buzowicz.Controllers
{
    [Route("api/products")]
    public class ProductsApiController : ControllerBase
    {
        public IActionResult Index(ProductModel product)
        {
            return Ok();
        }
    }
}
