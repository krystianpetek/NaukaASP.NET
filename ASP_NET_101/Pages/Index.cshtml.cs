using Microsoft.AspNetCore.Mvc;
using ASP_NET_101.Pages.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_101.Models;

namespace ASP_NET_101.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService ProductService { get; set; }
        public IEnumerable<Product> Products { get; private set; }
        public IndexModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            ProductService = productService;
            _logger = logger;
        }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
