using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using MyFirstMVCApp.Models;

namespace MyFirstMVCApp.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes= 1)
        {
            ViewData["Message"] = "Hello" + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }

        public IActionResult Welcome2(int id)
        {
            ViewData["liczba"] = id;
            return View();
        }
    }
}
