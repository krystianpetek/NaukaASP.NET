using Lab5Buzowicz.Models;
using Lab5Buzowicz.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lab5Buzowicz.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        public ProductsController(IProductService serv)
        {
            _service = serv;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductModel model)
        {
            await _service.Add(model);
            return View();
        }
        public IActionResult Index([FromRoute]int? id)
        {
            var lista = _service.List();
            var g = _service.Index(id);
            return View((lista,g));
        }
    }
}
