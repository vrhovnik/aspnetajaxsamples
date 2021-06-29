using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AjaxWebDemo.Models;

namespace AjaxWebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger) => this.logger = logger;

        public IActionResult Index() => View();

        public IActionResult PartialSample()
        {
            return View(StaticDataSource.Data);
        }

        public IActionResult GetPartial(string surname)
        {
            var list = StaticDataSource.Data;
            if (!string.IsNullOrEmpty(surname))
                list = list.Where(d => d.Surname.ToLower().Contains(surname)).ToList();
            return PartialView("_Persons", list);
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel
            {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}