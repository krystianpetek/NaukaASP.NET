using Lab4Buzowicz.Database;
using Lab4Buzowicz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4Buzowicz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger,AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index(int? id)
        {
            if(id == null || id == 0)
            {

                return View();
            }
            else
            {
                var student = _context.studenci.Where(x => x.id == id).FirstOrDefault();
                return View(student);
            }
        }
        
        [HttpGet]
        public IActionResult PrzekazaneDane(int? id)
        {
            if(id == null || id == 0)
            {

                return View();
            }
            else
            {
                var student = _context.studenci.Where(x => x.id == id).FirstOrDefault();
                return View(student);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
