using Lab3Buzowicz.Database;
using Lab3Buzowicz.Entities;
using Lab3Buzowicz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3Buzowicz.Controllers
{
    public class ProduktyController : Controller
    {
        private readonly AppDbContext _context;
        public ProduktyController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProduktModel produkt)
        {
            var entity = new ProduktEntity
            {
                Name = produkt.Name,
                Description = produkt.Description,
                IsVisible = produkt.IsVisible
            };

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> List(string name)
        {
            IQueryable<ProduktEntity> produktQuery = _context.Products;

            if(!string.IsNullOrEmpty(name))
            {
                produktQuery.Where(x=>x.Name.Contains(name));
            }

            var produkty = await produktQuery.ToListAsync();
            return View(produkty);
        }
    }
}
