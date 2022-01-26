using Lab4Buzowicz.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4Buzowicz.Views.Shared.Components.ViewComponents
{
    public class VisibleStudentsList : ViewComponent
    {
        private readonly AppDbContext _dbContext;
        public VisibleStudentsList(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<IViewComponentResult> InvokeAsync(int max = 3)
        {
            var studenci = await _dbContext.studenci.Where(x=>x.wiek > 17).Take(max).ToListAsync();
            return View("Default",studenci);
        }
    }
}
