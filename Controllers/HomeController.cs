using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class HomeController : Controller // Ao ser digitado no browser home, ele vai chamar o index()
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About() // Ao ser digitado no browser home/about, ele vai chamar o about()
        {
            ViewData["Message"] = "O Gustavo é Foda meu camarada!!!.";
            ViewData["Email"] = "gustavaomorais@hotmail.com";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
