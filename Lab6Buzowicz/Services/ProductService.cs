using Lab5Buzowicz;
using Lab5Buzowicz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Buzowicz.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductService(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, IHttpContextAccessor
        httpContextAccessor)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task Add(ProductModel product)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var entity = new ProductEntity
            {
                Name = product.Name,
                Description = product.Description,
                IsVisible = product.IsVisible,
                Owner = currentUser,
            };
            await _dbContext.uzytkownicy.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProductEntity>> GetAll(string name)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            IQueryable<ProductEntity> productsQuery = _dbContext.uzytkownicy;
            productsQuery = productsQuery.Where(x => x.Owner == currentUser);
            if (!string.IsNullOrEmpty(name))
            {
                productsQuery = productsQuery.Where(x => x.Name.Contains(name));
            }
            return await productsQuery.ToListAsync();
        }
    }
}
