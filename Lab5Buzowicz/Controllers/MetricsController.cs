using Lab5Buzowicz.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab5Buzowicz.Controllers
{
    public class MetricsController : Controller
    {
        private readonly IMetricsCollector _metryka;
        public MetricsController(IMetricsCollector metryka)
        {
            _metryka = metryka;
        }

        public IActionResult Index()
        {
            var lista = _metryka.GetEndpointStats();
            return View(lista);
        }
    }
}
