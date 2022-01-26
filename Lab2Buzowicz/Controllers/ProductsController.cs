using Microsoft.AspNetCore.Mvc;
using Lab2Buzowicz.Models;

namespace Lab2Buzowicz.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductModel product)
        {
            var viewModel = new ProductStatsViewModel
            {
                NameLength = product.Name.Length,
                DescriptionLength = product.Description.Length
            };
            return View(viewModel);
        }
    }
}
