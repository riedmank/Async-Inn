using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Index Page of Async Inn
        /// </summary>
        /// <returns>Returns Index view</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
