using Lab5Buzowicz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5Buzowicz.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(ProductModel product)
        {
            var entity = new ProductEntity()
            {
                Name = product.Name,
                Description = product.Description,
                IsVisible = product.IsVisible
            };

            await _context.products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public ProductEntity Index(int? id)
        {
            if (id == null || id == 0)
            {
                return new ProductEntity();
            }
            var produkt = _context.products.Where(x => x.Id == id).FirstOrDefault();
            return produkt;
            
        }

        public List<ProductEntity> List()
        {
            var produkty = _context.products.ToList();
            return produkty;
        }
    }
}
